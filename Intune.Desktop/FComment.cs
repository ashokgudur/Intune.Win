using Intune.Desktop.Properties;
using InTune.Domain;
using IntuneChat.Model;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Intune.Desktop
{
    public partial class FComment : Form
    {
        public User ByUser { get; set; }
        public User ToUser { get; set; }
        public Account Account { get; set; }
        public Entry Entry { get; set; }

        private DateTime _lastDate;

        public FComment()
        {
            InitializeComponent();
        }

        private void FComment_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resources.IntuneComment;
                Comment[] comments = null;
                this.Text = Session.GetFormTitle();

                if (Entry != null)
                {
                    lblHead.Text = string.Format("{0} Entry", Account.Name);
                    lblTitle.Text = string.Format("{0}:\n{1} on {2}\nof Qty: {3} and {4}", Account.Name, Entry.Notes, Entry.TxnDate.ToShortDateString(), Entry.Quantity, Entry.Amount.ToString("C2", CultureInfo.CurrentCulture));
                    comments = IntuneService.GetEntryComments(Entry.Id, ByUser.Id);
                }
                else if (Account != null)
                {
                    //TODO: could display profile and photo and can display summary of a/c
                    lblHead.Text = Account.Name;
                    lblTitle.Text = string.Format("Comments on\n{0}", Account.Name);
                    comments = IntuneService.GetAccountComments(Account.Id, ByUser.Id);
                }
                else
                {
                    //TODO: could display profile and photo etc.
                    lblHead.Text = string.Format("{0}@Intune", ToUser.Name);
                    lblTitle.Text = string.Format("Conversation between you and {0}", ToUser.Name);
                    comments = IntuneService.GetContactComments(ByUser.Id, ToUser.Id);
                }

                renderComments(comments);
                rtbComments.ScrollToCaret();
                txtComment.Focus();
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

        private void renderComments(Comment[] comments)
        {
            var dates = comments.Select(c => c.DateTimeStamp.Date).Distinct().ToArray();

            foreach (var date in dates)
            {
                renderCommentDay(date);

                foreach (var comment in comments
                    .Where(c => c.DateTimeStamp.Date == date)
                    .OrderBy(c => c.Id).Select(c => c))
                {
                    renderComment(comment);
                }
            }
        }

        private void renderCommentDay(DateTime commentDate)
        {
            if (_lastDate == null || _lastDate != commentDate)
            {
                rtbComments.SelectionBullet = false;
                rtbComments.SelectionAlignment = HorizontalAlignment.Center;
                rtbComments.SelectionColor = Color.Red;
                rtbComments.SelectionFont = new Font(rtbComments.SelectionFont, FontStyle.Bold);
                rtbComments.AppendText(string.Format("{0}\n", commentDate.ToString("dddd, MMMM dd, yyyy")));

                _lastDate = commentDate;
            }
        }

        private void renderComment(Comment comment)
        {
            renderCommentDay(comment.DateTimeStamp.Date);

            rtbComments.SelectionBullet = comment.Status == CommentStatus.Unread;
            rtbComments.SelectionAlignment = HorizontalAlignment.Left;
            rtbComments.SelectionColor = Color.Green;
            rtbComments.SelectionFont = new Font(rtbComments.SelectionFont.FontFamily, 7.0F, FontStyle.Regular);
            //rtbComments.AppendText(string.Format("[{0}] ", comment.DateTimeStamp.ToString("hh:mm:tt")));
            rtbComments.AppendText(getTimeSpan(comment.DateTimeStamp));

            var name = comment.ByUserName == Session.CurrentUser.Name ? "Me" : comment.ByUserName;
            rtbComments.SelectionColor = name == "Me" ? Color.Blue : Color.Purple;
            rtbComments.SelectionFont = new Font(rtbComments.SelectionFont.FontFamily, 10.0F, FontStyle.Bold);
            rtbComments.AppendText(string.Format("{0}: ", name));

            rtbComments.SelectionColor = Color.Black;
            rtbComments.SelectionFont = new Font(rtbComments.SelectionFont, FontStyle.Regular);
            rtbComments.AppendText(string.Format("{0}\n", comment.CommentText));
            rtbComments.SelectionBullet = false;
        }

        private string getTimeSpan(DateTime dateTimeStamp)
        {
            var ts = DateTime.Now.Subtract(dateTimeStamp);
            if (ts.TotalMinutes < 30)
            {
                if (ts.TotalSeconds < 30)
                    return string.Format("[{0}sec ago] ", Math.Round(ts.TotalSeconds));
                else
                    return string.Format("[{0}min ago] ", Math.Round(ts.TotalMinutes));
            }
            else
                return string.Format("[{0}] ", dateTimeStamp.ToString("hh:mm:tt"));
        }

        private string getTimeSpanOld(DateTime dateTimeStamp)
        {
            var ts = DateTime.Now.Subtract(dateTimeStamp);

            if (ts.TotalDays > 1)
                return string.Format("[{0}] ", dateTimeStamp.ToString("hh:mm:tt"));

            if (dateTimeStamp.Date.AddDays(1) == DateTime.Now.Date)
                return string.Format("[Y'day {0}]", dateTimeStamp.ToString("hh:mm:tt"));

            if (dateTimeStamp.Date == DateTime.Now.Date)
            {
                if (ts.TotalHours > 6)
                    return string.Format("[Today {0}] ", dateTimeStamp.ToString("hh:mm:tt"));

                if (ts.TotalHours > 1)
                    return string.Format("[{0}hrs ago] ", Math.Round(ts.TotalHours));

                if (ts.TotalMinutes > 1)
                    return string.Format("[{0}min ago] ", Math.Round(ts.TotalMinutes));

                if (ts.TotalSeconds > 1)
                    return string.Format("[{0}sec ago] ", Math.Round(ts.TotalSeconds));
            }

            return string.Format("[{0}secs ago]", ts.Seconds);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                addComment();
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

        public void DisplayComment(ChatMessage chatMessage)
        {
            var comment = new Comment
            {
                ByUserName = chatMessage.ByName,
                CommentText = chatMessage.Text,
                DateTimeStamp = chatMessage.DateTimeStamp,
            };

            renderComment(comment);
            rtbComments.ScrollToCaret();
        }

        private void addComment()
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text))
                return;

            var comment = new Comment
            {
                ByUserId = ByUser.Id,
                ToUserId = ToUser == null ? 0 : ToUser.Id,
                AccountId = Account == null ? 0 : Account.Id,
                EntryId = Entry == null ? 0 : Entry.Id,
                CommentText = txtComment.Text,
                DateTimeStamp = DateTime.Now,
            };

            comment = IntuneService.AddComment(comment);

            var chatMessage = new ChatMessage
            {
                ByEmail = ByUser.Email,
                ByName = ByUser.Name,
                ToEmail = ToUser == null ? "" : ToUser.Email,
                ToName = ToUser == null ? "" : ToUser.Name,
                Text = comment.CommentText,
                ByUserId = comment.ByUserId,
                ToUserId = comment.ToUserId,
                AccountId = comment.AccountId,
                EntryId = comment.EntryId,
                DateTimeStamp = comment.DateTimeStamp,
            };

            Session.CommentFormManager.SendMessage(chatMessage);
            DisplayComment(chatMessage);
            txtComment.Text = "";
            txtComment.Focus();
        }

        private void FComment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Session.CommentFormManager.RemoveForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
