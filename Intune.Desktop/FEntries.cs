using Intune.Desktop.Properties;
using InTune.Domain;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public partial class FEntries : Form
    {
        public Account Account { get; set; }
        private bool _isContactsView = true;

        public FEntries()
        {
            InitializeComponent();
        }

        private void FEntries_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
                lblHead.Text = Account.Name;
                lnkShareAccount.Visible = Account.Role == UserAccountRole.Owner;
                buildListColumns();
                switchView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkSwitch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
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

        private void buildListColumns()
        {
            lstEntries.Columns.Clear();
            lstEntries.Columns.Add("Date", 67);
            lstEntries.Columns.Add("Txn", 48);
            lstEntries.Columns.Add("Qty.", 51, HorizontalAlignment.Right);
            lstEntries.Columns.Add("Amount", 118, HorizontalAlignment.Right);

            lstContacts.Columns.Clear();
            lstContacts.Columns.Add("Contact Name", 214);
            lstContacts.Columns.Add("Intune", 70);
        }

        private void switchView()
        {
            if (_isContactsView)
                showEntriesView();
            else
                showContactsView();

            refreshList();
        }

        private void refreshList()
        {
            if (_isContactsView)
                loadContacts();
            else
                loadEntries();
        }

        private void loadEntries()
        {
            lstEntries.SelectedIndices.Clear();
            lstEntries.Items.Clear();

            double totalCreditQuantity = 0.00;
            double totalDebitQuantity = 0.00;

            decimal totalCreditAmount = 0.00M;
            decimal totalDebitAmount = 0.00M;

            var entries = IntuneService.GetAccountEntries(Account.Id);

            foreach (var entry in entries)
            {
                var lineColor = Color.Blue;

                if (entry.VoidId > 0)
                    lineColor = Color.DimGray;
                else if (entry.TxnType == TxnType.Paid || entry.TxnType == TxnType.Issu)
                    lineColor = Account.Role == UserAccountRole.Collaborator ? Color.Red : Color.Green;
                else if (entry.TxnType == TxnType.Rcvd)
                    lineColor = Account.Role == UserAccountRole.Collaborator ? Color.Green : Color.Red;

                var lvi = lstEntries.Items.Add(entry.TxnDate.ToString("dd-MM-yy"));
                lvi.ForeColor = lineColor;
                lvi.Font = new Font(lstEntries.Font, FontStyle.Regular);

                var lvsi = lvi.SubItems.Add(getTxnType(entry));
                lvsi = lvi.SubItems.Add(entry.Quantity.ToString("#0"));
                lvsi = lvi.SubItems.Add(entry.Amount.ToString("C2", CultureInfo.CurrentCulture));
                lvi.Tag = entry;

                if (entry.TxnType == TxnType.Paid || entry.TxnType == TxnType.Issu)
                {
                    totalCreditAmount += entry.Amount;
                    totalCreditQuantity += entry.Quantity;
                }
                else
                {
                    totalDebitAmount += entry.Amount;
                    totalDebitQuantity += entry.Quantity;
                }
            }

            if (lstEntries.Items.Count > 0)
            {
                lstEntries.SelectedIndices.Add(0);
                var balanceAmount = totalCreditAmount - totalDebitAmount;
                var balanceQuantity = totalCreditQuantity - totalDebitQuantity;
                addEntryRow("Total:", getTotalsTxnType("Paid"), totalCreditQuantity, totalCreditAmount, Color.Black, FontStyle.Regular);
                addEntryRow("Total:", getTotalsTxnType("Rcvd"), totalDebitQuantity, totalDebitAmount, Color.Purple, FontStyle.Regular);
                var balanceTitle = balanceAmount == 0 ? "Zero" : balanceAmount > 0 ? getBalanceTitle("Rcvbl") : getBalanceTitle("Paybl");
                addEntryRow("Balance:", balanceTitle, balanceQuantity, Math.Abs(balanceAmount), Color.Blue, FontStyle.Regular);
            }

            lnkComment.Visible = lstEntries.Items.Count > 0;
            lnkVoidEntry.Visible = lstEntries.Items.Count > 0 &&
                (Account.Role == UserAccountRole.Owner || Account.Role == UserAccountRole.Impersonator);
            lstEntries.Select();
        }

        private string getTotalsTxnType(string ofType)
        {
            if (Account.Role == UserAccountRole.Collaborator)
                return ofType == "Paid" ? "Rcvd" : "Paid";
            else
                return ofType == "Paid" ? "Paid" : "Rcvd";
        }

        private string getBalanceTitle(string ofType)
        {
            if (Account.Role == UserAccountRole.Collaborator)
                return ofType == "Rcvbl" ? "Paybl" : "Rcvbl";
            else
                return ofType == "Rcvbl" ? "Rcvbl" : "Paybl";
        }

        private string getTxnType(Entry entry)
        {
            if (Account.Role != UserAccountRole.Collaborator)
                return entry.TxnType.ToString();

            if (entry.TxnType == TxnType.Paid || entry.TxnType == TxnType.Issu)
                return TxnType.Rcvd.ToString();

            if (entry.Amount >= 0)
                return TxnType.Paid.ToString();
            else
                return TxnType.Issu.ToString();
        }

        private void addEntryRow(string title, string txnType, double totalQuantity, decimal totalAmount, Color color, FontStyle fontStyle)
        {
            var lvi = lstEntries.Items.Add(title);
            lvi.SubItems.Add(txnType);
            lvi.SubItems.Add(totalQuantity.ToString("#0"));
            lvi.SubItems.Add(totalAmount.ToString("C2", CultureInfo.CurrentCulture));
            lvi.ForeColor = color;
            lvi.Font = new Font(lstEntries.Font, fontStyle);
            //lvi.Tag = entry;
        }

        private void loadContacts()
        {
            lstContacts.SelectedIndices.Clear();
            lstContacts.Items.Clear();
            var contacts = IntuneService.GetAccountContacts(Session.CurrentUser.Id, Account.Id);
            foreach (var contact in contacts)
            {
                var lvi = lstContacts.Items.Add(contact.Name);
                lvi.ForeColor = Color.Blue;
                lvi.Font = new Font(lstContacts.Font, FontStyle.Regular);
                var intune = contact.HasIntune() ? "Yes" : "No";
                var lvsi = lvi.SubItems.Add(intune);
                lvi.Tag = contact;
            }

            if (lstContacts.Items.Count > 0)
                lstContacts.SelectedIndices.Add(0);

            lnkComment.Visible = lstContacts.Items.Count > 0;
            lstContacts.Select();
        }

        private void showContactsView()
        {
            pnlContact.Visible = true;
            lstContacts.Visible = true;
            pnlEntries.Visible = false;
            lstEntries.Visible = false;
            lnkSwitch.Text = "Entries";
            lblTitle.Text = string.Format("Account contacts associated with {0}\nUse <New> to associate a new contact.", Account.Name);
            txtNotes.Visible = false;
            _isContactsView = true;
        }

        private void showEntriesView()
        {
            pnlContact.Visible = false;
            lstContacts.Visible = false;
            pnlEntries.Visible = true;
            lstEntries.Visible = true;
            lnkSwitch.Text = "Contacts";
            lblTitle.Text = string.Format("{0} Entries.\nUse <New> to add new entry. Select the entry and chose Void to reverse that entry", Account.Name);
            txtNotes.Visible = true;
            txtNotes.Text = "";
            _isContactsView = false;

            lnkAddEntry.Visible = (Account.Role == UserAccountRole.Owner || Account.Role == UserAccountRole.Impersonator);
            lnkVoidEntry.Visible = (Account.Role == UserAccountRole.Owner || Account.Role == UserAccountRole.Impersonator);
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

        private void lnkAddContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var f = new FContacts();
                var result = f.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                Cursor.Current = Cursors.WaitCursor;
                var contacts = f.SelectedContacts;
                foreach (var contact in contacts)
                {
                    var acu = new AccountContactUser
                    {
                        AccountId = Account.Id,
                        ContactId = contact.Id,
                        UserId = Session.CurrentUser.Id
                    };
                    IntuneService.AddAccountContact(acu);
                }

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

        private void lnkAddEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var f = new FEntry();
                f.Account = Account;
                f.ShowDialog();
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

        private void lnkRemoveContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //Q1: Can a shared contact be removed from account?
                //    A. May be Unshare can be done.
                //       You've shared this account with this contact. Removing will do unshare.


                //if (lstContacts.SelectedItems.Count == 0)
                //    return;

                //Cursor.Current = Cursors.WaitCursor;
                //var contact = lstContacts.SelectedItems[0].Tag as Contact;
                //IntuneService.RemoveAccountContact(Account.Id, contact.Id);
                //refreshList();
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
                var f = new FAccountShare();
                f.Account = Account;
                var result = f.ShowDialog();

                if (_isContactsView)
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

        private void lnkComment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_isContactsView)
                    contactComment();
                else
                    accountEntryComment();
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
            lvi.ImageIndex = -1;
        }

        private void accountEntryComment()
        {
            var lvi = lstEntries.SelectedItems[0];
            var entry = lvi.Tag as Entry;
            var cf = Session.CommentFormManager.GetAccountEntryCommentForm(Account, entry);
            cf.Show();
            lvi.ImageIndex = -1;
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = lstContacts.SelectedItems.Count == 1;
                lnkComment.Visible = itemSelected;
                lnkRemoveContact.Visible = itemSelected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = lstEntries.SelectedItems.Count == 1;
                lnkComment.Visible = itemSelected;
                lnkVoidEntry.Visible = itemSelected;
                txtNotes.Text = "";
                if (!itemSelected)
                    return;

                var entry = lstEntries.SelectedItems[0].Tag as Entry;
                lnkComment.Visible = entry != null;
                lnkVoidEntry.Visible = (Account.Role == UserAccountRole.Owner || Account.Role == UserAccountRole.Impersonator) && entry != null && entry.VoidId == 0;
                txtNotes.Text = entry == null ? "" : entry.Notes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkVoidEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!shouldVoidEntry())
                    return;

                Cursor.Current = Cursors.WaitCursor;
                var entry = lstEntries.SelectedItems[0].Tag as Entry;

                var voidEntry = new Entry
                {
                    UserId = Session.CurrentUser.Id,
                    AccountId = entry.AccountId,
                    Notes = composeVoidNotes(entry),
                    TxnType = makeVoidTxnType(entry),
                    TxnDate = DateTime.Now.Date,
                    Quantity = entry.Quantity,
                    Amount = entry.Amount,
                    VoidId = entry.Id,
                };

                IntuneService.AddAccountEntry(voidEntry);
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

        private TxnType makeVoidTxnType(Entry entry)
        {
            if (entry.TxnType == TxnType.Paid || entry.TxnType == TxnType.Issu)
                return TxnType.Rcvd;
            else if (entry.Amount > 0)
                return TxnType.Paid;
            else
                return TxnType.Issu;
        }

        private string composeVoidNotes(Entry entry)
        {
            return string.Format("Void of {0} on {1} of Qty: {2} and {3}", entry.Notes, entry.TxnDate.ToShortDateString(), entry.Quantity, entry.Amount.ToString("C2", CultureInfo.CurrentCulture));
        }

        private bool shouldVoidEntry()
        {
            var result = MessageBox.Show("Please confirm that you want to void this entry.", "Void Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            return result == DialogResult.OK;
        }
    }
}
