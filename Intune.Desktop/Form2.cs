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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Groups.Clear();
            listView1.MultiSelect = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            //listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.Groups.Clear();
            listView1.Groups.Clear();

            listView1.Columns.Add("", 19);
            listView1.Columns.Add("From", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("Message", 200);
            listView1.Columns.Add("At", 60);

            var comments = IntuneService.GetAccountComments(1, 2);
            foreach (var comment in comments)
            {
                var name = comment.ByUserName == "Ashok Guduru" ? "Me:" : comment.ByUserName + ":";

                var lvi = listView1.Items.Add("");
                lvi.ImageIndex = 9;
                lvi.UseItemStyleForSubItems = false;

                var lvsi = lvi.SubItems.Add(name);
                lvsi.Font = new Font(listView1.Font, FontStyle.Bold);
                lvsi.ForeColor = name == "Me:" ? Color.Blue : Color.Purple;

                lvsi = lvi.SubItems.Add(comment.CommentText);
                lvsi.Font = new Font(listView1.Font, FontStyle.Regular);
                lvsi.ForeColor = Color.Black;

                lvsi = lvi.SubItems.Add(comment.DateTimeStamp.ToString("hh:mm:tt"));
                lvsi.Font = new Font("Tahoma", 7.0F, FontStyle.Regular);
                lvsi.ForeColor = Color.Green;
            }
        }
    }
}
