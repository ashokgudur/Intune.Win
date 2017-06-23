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
    public partial class FAccount : Form
    {
        public FAccount()
        {
            InitializeComponent();
        }

        private void FAccount_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
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
                lblMessage.Text = "Trying to add this account...";
                var account = new Account
                {
                    Name = txtName.Text.Trim(),
                    UserId = Session.CurrentUser.Id,
                    AddedOn = DateTime.Now,
                };

                if (!account.IsValid())
                {
                    MessageBox.Show("Please enter account name");
                    return;
                }

                IntuneService.AddAccount(account);
                lblMessage.Text = "Account added successfully.";
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
    }
}
