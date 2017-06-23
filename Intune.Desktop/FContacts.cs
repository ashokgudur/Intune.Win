using Intune.Desktop.Properties;
using InTune.Domain;
using System;
using System.Collections;
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
    public partial class FContacts : Form
    {
        public IList<Contact> SelectedContacts { get; set; }
        public bool ShowOnlyIntuneContacts { get; set; }

        public FContacts()
        {
            InitializeComponent();
        }

        private void FContacts_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
                buildListColumns();
                loadContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buildListColumns()
        {
            lstContacts.Columns.Clear();
            lstContacts.Columns.Add("Contact Name", 210);
            lstContacts.Columns.Add("Intune", 70);
        }

        private void loadContacts()
        {
            lstContacts.SelectedIndices.Clear();
            lstContacts.Items.Clear();
            var contacts = IntuneService.GetAllContacts();
            foreach (var contact in contacts)
            {
                if (ShowOnlyIntuneContacts && !contact.HasIntune())
                    continue;

                var lvi = lstContacts.Items.Add(contact.Name);
                var intune = contact.HasIntune() ? "Yes" : "No";
                lvi.SubItems.Add(intune);
                lvi.ForeColor = Color.Blue;
                lvi.Font = new Font(lstContacts.Font, FontStyle.Regular);
                lvi.Tag = contact;
            }

            if (lstContacts.Items.Count > 0)
                lstContacts.SelectedIndices.Add(0);

            lstContacts.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SelectedContacts = new List<Contact>();
                foreach (ListViewItem item in lstContacts.CheckedItems)
                    SelectedContacts.Add(item.Tag as Contact);

                Close();
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
