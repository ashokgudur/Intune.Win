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
    public partial class FUser : Form
    {
        public FUser()
        {
            InitializeComponent();
        }

        private void FUser_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtMobile.Text = "";
                txtAtUserName.Text = "";
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessage.Text = "Registering user...";
                var user = new User
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    AtUserName = txtAtUserName.Text.Trim(),
                    Mobile = txtMobile.Text.Trim(),
                    CreatedOn = DateTime.Now,
                };

                if (!user.IsValid())
                {
                    MessageBox.Show("Please enter all the details.");
                    return;
                }

                var contactData = IntuneService.RegisterUser(user);
                lblMessage.Text = "User registeration successful";
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
