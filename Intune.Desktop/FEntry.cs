using Intune.Desktop.Properties;
using InTune.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public partial class FEntry : Form
    {
        public Account Account { get; set; }

        public FEntry()
        {
            InitializeComponent();
        }

        private void FEntry_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneMain;
                this.Text = Session.GetFormTitle();
                lblHead.Text = Account.Name;
                this.lblTitle.Text = string.Format("{0}:\nPlease enter below details of new entry", Account.Name);
                this.dtpTxnDate.Value = DateTime.Now.Date;
                fillTxnTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillTxnTypes()
        {
            Utils.LoadEnumListItems(cmbTxnType, typeof(TxnType));
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = isValidForCurrency(sender as TextBox, e);
        }

        private bool isValidForCurrency(TextBox textBox, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return false;

            //TODO: provide option to whether to allow negatives or not and use the following code to check that
            //if (e.KeyChar == '-' && !textBox.Text.Contains('-'))
            //{
            //    textBox.Text = @"-" + textBox.Text;
            //    textBox.Select(textBox.TextLength, 0);
            //    return true;
            //}

            if (e.KeyChar == '.' && !textBox.Text.Contains('.'))
            {
                if (String.IsNullOrEmpty(textBox.Text) || textBox.Text == @"-")
                {
                    textBox.Text += @"0.";
                    textBox.Select(textBox.TextLength, 0);
                    return true;
                }
                return false;
            }

            if (!NumLength.IsIntegerLong(textBox))
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    if (textBox.Text == @"0")
                        textBox.Text = "";

                    return false;
                }
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessage.Text = "Trying to add this entry...";
                var txnType = (TxnType)cmbTxnType.SelectedValue;
                var entry = new Entry
                {
                    UserId = Session.CurrentUser.Id,
                    AccountId = Account.Id,
                    Notes = txtNotes.Text.Trim(),
                    TxnType = txnType,
                    TxnDate = dtpTxnDate.Value,
                    Quantity = Convert.ToDouble(txtQuantity.Text),
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    VoidId = 0
                };

                if (!entry.IsValid())
                {
                    MessageBox.Show("Please enter details");
                    lblMessage.Text = "";
                    return;
                }

                IntuneService.AddAccountEntry(entry);
                lblMessage.Text = "Entry added successfully.";
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
