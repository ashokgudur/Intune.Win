using Intune.Desktop.Properties;
using InTune.Domain;
using IntuneChat.Model;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public partial class FMain : Form
    {
        private static string chatServerUri
        {
            get
            {
#if DEBUG
                return @"http://localhost:59802/";
#else
                return StringCipher.Decrypt(@"U6HyCwIrLuTtcFl+BFVijmHIyVsbIsZRUCkp1CuXXoA=", @"SonyVaioZSeriesVPCZ1");
#endif
            }
        }

        private HubConnection _hubConnection = null;
        private IHubProxy _hubProxy = null;
        private bool _isContactsView = true;
        private int _selectedContactId = 0;

        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
                connectAsync();
                Session.CommentFormManager = new CommentFormManager(_hubProxy);
                buildListColumns();
                switchView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Session.CommentFormManager != null)
                    Session.CommentFormManager.Dispose();

                if (_hubConnection != null)
                {
                    _hubConnection.Stop();
                    _hubConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void connectAsync()
        {
            _hubConnection = new HubConnection(chatServerUri);
            fillHubConnectionHeaderInfo();
            _hubProxy = _hubConnection.CreateHubProxy("ChatHub");
            _hubProxy.On<ChatMessage>("AddComment", (chatMessage) =>
                            this.Invoke((Action)(() => processMessage(chatMessage))));
            try
            {
                await _hubConnection.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillHubConnectionHeaderInfo()
        {
            var userName = new KeyValuePair<string, string>("UserName", Session.CurrentUser.Name);
            var userEmail = new KeyValuePair<string, string>("UserEmail", Session.CurrentUser.Email);
            _hubConnection.Headers.Add(userName);
            _hubConnection.Headers.Add(userEmail);
        }

        private void processMessage(ChatMessage chatMessage)
        {
            var processed = Session.CommentFormManager.ProcessChatMessage(chatMessage);
            if (!processed)
                displayMessageIndicator(chatMessage);
        }

        private void displayMessageIndicator(ChatMessage chatMessage)
        {
            if (chatMessage.CommentType == CommentType.Entry)
                markAsAccountEntryHasUnreadComment(chatMessage);
            else if (chatMessage.CommentType == CommentType.Account)
                markAsAccountHasUnreadComment(chatMessage);
            else if (chatMessage.CommentType == CommentType.Contact)
                markAsContactHasUnreadComment(chatMessage);
        }

        private void markAsContactHasUnreadComment(ChatMessage chatMessage)
        {
            foreach (ListViewItem lvi in lstContacts.Items)
            {
                var contact = lvi.Tag as Contact;
                if (contact.ContactUserId == chatMessage.ByUserId)
                {
                    lvi.ImageIndex = 1;
                    return;
                }
            }
        }

        private void markAsAccountEntryHasUnreadComment(ChatMessage chatMessage)
        {
            //chatMessage.AccountId, chatMessage.EntryId
            //TODO: if the same account entries form is visible then inform the form to display an indicator.
        }

        private void markAsAccountHasUnreadComment(ChatMessage chatMessage)
        {
            foreach (ListViewItem lvi in lstAccounts.Items)
            {
                var account = lvi.Tag as Account;
                if (account.Id == chatMessage.AccountId)
                {
                    lvi.ImageIndex = 1;
                    if (!account.HasUnreadComments)
                        IntuneService.MarkAccountCommentAsUnread(chatMessage.AccountId, Session.CurrentUser.Id);

                    return;
                }
            }
        }

        private void buildListColumns()
        {
            lstAccounts.Columns.Clear();
            lstAccounts.Columns.Add("Account", 113);
            lstAccounts.Columns.Add("P", 22);
            lstAccounts.Columns.Add("Tx", 32);
            lstAccounts.Columns.Add("Balance", 117, HorizontalAlignment.Right);
            lstAccounts.SmallImageList = StatusImageList;

            lstContacts.Columns.Clear();
            lstContacts.Columns.Add("Contact Name", 214);
            lstContacts.Columns.Add("Intune", 70);
            lstContacts.SmallImageList = StatusImageList;
        }

        private void switchView()
        {
            if (_isContactsView)
                showAccountsView();
            else
                showContactsView();

            refreshList();
        }

        private void showAccountsView()
        {
            pnlContactsBar.Visible = false;
            lstContacts.Visible = false;
            pnlAccountsBar.Visible = true;
            lstAccounts.Visible = true;
            lblHead.Text = "Accounts - Intune";
            lblTitle.Text = "Please select the account you want to open and see the entries. Use <New> to create new account.";
            lnkSwitch.Text = "Contacts";
            _isContactsView = false;
        }

        private void showContactsView()
        {
            pnlContactsBar.Visible = true;
            lstContacts.Visible = true;
            pnlAccountsBar.Visible = false;
            lstAccounts.Visible = false;
            lblHead.Text = "Contacts - Intune";
            lblTitle.Text = "Please select the contact you want to filter accounts and see the entries. Use <New> to create new contact";
            lnkSwitch.Text = "Accounts";
            _isContactsView = true;
        }

        private void refreshList()
        {
            if (_isContactsView)
                loadContacts();
            else
                loadAccounts();
        }

        private void loadContacts()
        {
            lstContacts.SelectedIndices.Clear();
            lstContacts.Items.Clear();
            var contacts = IntuneService.GetAllContacts();
            foreach (var contact in contacts)
            {
                var lvi = lstContacts.Items.Add(contact.Name);
                var intune = contact.HasIntune() ? "Yes" : "No";
                lvi.SubItems.Add(intune);
                lvi.ForeColor = Color.Blue;
                lvi.Font = new Font(lstContacts.Font, FontStyle.Regular);
                lvi.Tag = contact;

                if (contact.HasUnreadComments)
                    lvi.ImageIndex = 0;
                else if (contact.HasComments)
                    lvi.ImageIndex = 2;
            }

            if (lstContacts.Items.Count > 0)
                lstContacts.SelectedIndices.Add(0);

            lstContacts.Select();
        }

        private void loadAccounts()
        {
            lstAccounts.SelectedIndices.Clear();
            lstAccounts.Items.Clear();
            var accounts = IntuneService.GetAllAccounts(_selectedContactId);
            foreach (var account in accounts)
            {
                var lineColor = Color.Blue;

                if (account.Role != UserAccountRole.Owner)
                    lineColor = Color.Brown;

                var lvi = lstAccounts.Items.Add(account.Name);
                lvi.ForeColor = lineColor;
                lvi.Font = new Font(lstAccounts.Font, FontStyle.Regular);
                lvi.UseItemStyleForSubItems = false;

                var lvsi = lvi.SubItems.Add(account.Role.ToString().Substring(0, 1));
                lvsi.ForeColor = lineColor;
                lvsi.Font = new Font(lstAccounts.Font, FontStyle.Regular);

                var txn = account.Balance == 0 ? account.HasEntries ? "++" : "NA"
                                    : account.Balance > 0 ? getBalanceTitle(account, "Rbl") : getBalanceTitle(account, "Pbl");

                lvsi = lvi.SubItems.Add(txn);
                var balanceColor = getBalanceColor(account);
                lvsi.ForeColor = account.Balance == 0 ? lineColor : balanceColor;
                lvsi.Font = new Font(lstAccounts.Font, FontStyle.Regular);

                lvsi = lvi.SubItems.Add(Math.Abs(account.Balance).ToString("C2", CultureInfo.CurrentCulture));
                lvsi.ForeColor = account.Balance == 0 ? lineColor : balanceColor;
                lvsi.Font = new Font(lstAccounts.Font, FontStyle.Regular);

                lvi.Tag = account;
                if (account.HasUnreadComments)
                    lvi.ImageIndex = 0;
                else if (account.HasComments)
                    lvi.ImageIndex = 2;
            }

            if (lstAccounts.Items.Count > 0)
                lstAccounts.SelectedIndices.Add(0);

            lstAccounts.Select();
        }

        private Color getBalanceColor(Account account)
        {
            if (account.Role == UserAccountRole.Collaborator)
                return account.Balance > 0 ? Color.Red : Color.Green;
            else
                return account.Balance > 0 ? Color.Green : Color.Red;
        }

        private string getBalanceTitle(Account account, string ofType)
        {
            if (account.Role == UserAccountRole.Collaborator)
                return ofType == "Rbl" ? "Pbl" : "Rbl";
            else
                return ofType == "Rbl" ? "Rbl" : "Pbl";
        }

        private void lnkNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Hide();
                var f = new FAccount();
                f.ShowDialog();
                refreshList();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                refreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lstAccounts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                openAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkOpenAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                openAccount();
                refreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void openAccount()
        {
            var lvi = lstAccounts.SelectedItems[0];
            var account = lvi.Tag as Account;
            this.Hide();
            var f = new FEntries();
            f.Account = account;
            f.ShowDialog();
            refreshList();
            this.Show();
        }

        private void lnkSwitch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _selectedContactId = 0;
                switchView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkNewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Hide();
                var f = new FContact();
                f.ShowDialog();
                refreshList();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkOpenContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Hide();
                var f = new FContact();
                f.Contact = lstContacts.SelectedItems[0].Tag as Contact;
                f.ShowDialog();
                //refreshList();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkShareAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var account = lstAccounts.SelectedItems[0].Tag as Account;
                var f = new FAccountShare();
                f.Account = account;
                var result = f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkInviteContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Send invitation via email...
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = lstContacts.SelectedItems.Count == 1;
                lnkComment.Visible = itemSelected;
                lnkInviteContact.Visible = itemSelected;
                lnkOpenContact.Visible = itemSelected;
                if (!itemSelected)
                    return;

                var contact = lstContacts.SelectedItems[0].Tag as Contact;
                lnkInviteContact.Visible = !contact.HasIntune();

                if (_isContactsView)
                    lnkComment.Visible = contact.HasIntune();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstContacts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _selectedContactId = getSelectedContactId();
                switchView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private int getSelectedContactId()
        {
            if (lstContacts.SelectedItems.Count == 0)
                return 0;

            var contact = lstContacts.SelectedItems[0].Tag as Contact;
            return contact.Id;
        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = lstAccounts.SelectedItems.Count == 1;
                lnkComment.Visible = itemSelected;
                lnkShareAccount.Visible = itemSelected;
                lnkOpenAccount.Visible = itemSelected;

                if (!itemSelected)
                    return;

                var account = lstAccounts.SelectedItems[0].Tag as Account;
                lnkShareAccount.Visible = account.Role == UserAccountRole.Owner;

                //lnkInviteContact.Visible = !contact.HasIntune;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkComment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_isContactsView)
                    contactComment();
                else
                    accountComment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void contactComment()
        {
            var lvi = lstContacts.SelectedItems[0];
            var contact = lvi.Tag as Contact;
            var cf = Session.CommentFormManager.GetContactCommentForm(contact);
            cf.Show();
            lvi.ImageIndex = contact.HasComments ? 2 : -1;
            lstContacts.Refresh();
        }

        private void accountComment()
        {
            var lvi = lstAccounts.SelectedItems[0];
            var account = lvi.Tag as Account;
            var cf = Session.CommentFormManager.GetAccountCommentForm(account);
            cf.Show();
            lvi.ImageIndex = account.HasComments ? 2 : -1;
            lstAccounts.Refresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_isContactsView)
                {
                    _selectedContactId = getSelectedContactId();
                    switchView();
                }
                else
                    openAccount();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
