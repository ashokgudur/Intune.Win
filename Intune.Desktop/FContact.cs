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
    public partial class FContact : Form
    {
        public Contact Contact { get; set; }

        public FContact()
        {
            InitializeComponent();
        }

        private void FContact_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
                fillForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillForm()
        {
            if (Contact == null)
                return;

            lblTitle.Text = string.Format("Contact details of {0}", Contact.Name);
            txtName.Text = Contact.Name;
            txtEmail.Text = Contact.Email;
            txtMobile.Text = Contact.Mobile;
            txtAddress.Text = Contact.Address;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Contact contact = null;
                
                if (Contact == null)
                {
                    lblMessage.Text = "Trying to add this contact...";
                    contact = new Contact();
                    contact.UserId = Session.CurrentUser.Id;
                    contact.CreatedOn = DateTime.Now;
                }
                else
                {
                    lblMessage.Text = "Trying to save this contact...";
                    contact = Contact;
                }

                fillContact(contact);

                if (!contact.IsValid())
                {
                    MessageBox.Show("Please enter all the details.");
                    return;
                }

                if (Contact == null)
                {
                    IntuneService.AddContact(contact);
                    lblMessage.Text = "Contact added successfully.";
                }
                else
                {
                    IntuneService.UpdateContact(contact);
                    lblMessage.Text = "Contact saved successfully.";
                }

                this.Hide();
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

        private void fillContact(Contact contact)
        {
            contact.Name = txtName.Text.Trim();
            contact.Email = txtEmail.Text.Trim();
            contact.Mobile = txtMobile.Text.Trim();
            contact.Address = txtAddress.Text.Trim();
        }
    }
}
