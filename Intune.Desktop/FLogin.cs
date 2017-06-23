using Intune.Desktop.Properties;
using System;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            Icon = Resources.IntuneMain;
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Hide();
                var f = new FUser();
                f.ShowDialog();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessage.Text = "Trying to login to Intune...";
                var email = txtEmail.Text.Trim();
                var password = txtPassword.Text.Trim();
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter your login credentials");
                    return;
                }

                var user = IntuneService.Login(email, password);
                Session.CurrentUser = user;
                var msg = string.Format("{0} login successful", user.Name);
                lblMessage.Text = msg;
                var f = new FMain();
                this.Hide();
                f.ShowDialog();
                txtEmail.Text = "";
                txtPassword.Text = "";
                Session.CurrentUser = null;
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lblMessage.Text = "";
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter your email address");
                    txtEmail.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                lblMessage.Text = "Trying to send email containing your password";
                IntuneService.ForgotPassword(txtEmail.Text);
                lblMessage.Text = "Your password has been emailed.";
                MessageBox.Show("Your password has been emailed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lblMessage.Text = "";
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
