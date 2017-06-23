using Intune.Desktop.Properties;
using InTune.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public partial class FAccountShare : Form
    {
        public Account Account { get; set; }

        public FAccountShare()
        {
            InitializeComponent();
        }

        private void FAccountShare_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
                lblTitle.Text = string.Format(lblTitle.Text, Account.Name);
                fillUserRoles();
                buildListColumns();
                loadContacts(getSelectedAccountRole());
                cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillUserRoles()
        {
            var roles = Utils.GetEnumList(typeof(UserAccountRole));
            Utils.BindListControl(cmbRole, "Key", "Value", getUserRolesToBeFilled());
        }

        private List<KeyValuePair<int, string>> getUserRolesToBeFilled()
        {
            var roles = Utils.GetEnumList(typeof(UserAccountRole));

            if (Account.Role == UserAccountRole.Owner || Account.Role == UserAccountRole.Impersonator)
                roles.RemoveAt(0);
            else if (Account.Role == UserAccountRole.Collaborator)
                roles.RemoveRange(0, 2);
            else if (Account.Role == UserAccountRole.Viewer)
                roles.RemoveRange(0, 3);

            return roles;
        }

        private UserAccountRole getSelectedAccountRole()
        {
            return (UserAccountRole)cmbRole.SelectedValue;
        }

        private void buildListColumns()
        {
            lstContacts.Columns.Clear();
            lstContacts.Columns.Add("Contact Name", 284);
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                loadContacts(getSelectedAccountRole());
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

        private void loadContacts(UserAccountRole ofRole)
        {
            lstContacts.ItemChecked -= lstContacts_ItemChecked;
            lstContacts.SelectedIndices.Clear();
            lstContacts.Items.Clear();

            var contacts = IntuneService.GetAllContacts();
            var userIds = IntuneService.GetAccountUsers(Account.Id, ofRole);
            foreach (var contact in contacts)
            {
                if (!contact.HasIntune())
                    continue;

                var lvi = lstContacts.Items.Add(contact.Name);
                lvi.ForeColor = Color.Blue;
                lvi.Font = new Font(lstContacts.Font, FontStyle.Regular);
                lvi.Checked = userIds.Where(u => u == contact.ContactUserId).Count() > 0;
                lvi.Tag = contact;
            }

            if (lstContacts.Items.Count > 0)
                lstContacts.SelectedIndices.Add(0);

            lstContacts.Select();
            lstContacts.ItemChecked += lstContacts_ItemChecked;
        }

        private void lstContacts_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var acu = getAccountContactUser(e.Item.Tag as Contact);

                if (e.Item.Checked)
                    IntuneService.AddAccountUser(acu);
                else
                    IntuneService.DeleteAccountUser(acu);
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

        private AccountContactUser getAccountContactUser(Contact contact)
        {
            return new AccountContactUser
            {
                AccountId = Account.Id,
                ContactId = contact.Id,
                ContactUserId = contact.ContactUserId,
                UserId = Session.CurrentUser.Id,
                Role = getSelectedAccountRole(),
            };
        }
    }
}
