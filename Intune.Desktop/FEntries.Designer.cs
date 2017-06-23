namespace Intune.Desktop
{
    partial class FEntries
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblHead = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lnkComment = new System.Windows.Forms.LinkLabel();
            this.lnkShareAccount = new System.Windows.Forms.LinkLabel();
            this.lnkSwitch = new System.Windows.Forms.LinkLabel();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.pnlEntries = new System.Windows.Forms.Panel();
            this.lnkVoidEntry = new System.Windows.Forms.LinkLabel();
            this.lnkAddEntry = new System.Windows.Forms.LinkLabel();
            this.pnlContact = new System.Windows.Forms.Panel();
            this.lnkRemoveContact = new System.Windows.Forms.LinkLabel();
            this.lnkAddContact = new System.Windows.Forms.LinkLabel();
            this.lstEntries = new System.Windows.Forms.ListView();
            this.lstContacts = new System.Windows.Forms.ListView();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.pnlTitle.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlEntries.SuspendLayout();
            this.pnlContact.SuspendLayout();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Teal;
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.lblHead);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(407, 100);
            this.pnlTitle.TabIndex = 8;
            // 
            // lblHead
            // 
            this.lblHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHead.BackColor = System.Drawing.Color.Maroon;
            this.lblHead.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.Color.White;
            this.lblHead.Location = new System.Drawing.Point(0, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(407, 28);
            this.lblHead.TabIndex = 9;
            this.lblHead.Text = "Register new user";
            this.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(407, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Please select the account you want to open and entries into. Use <New Account> to" +
    " create new ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.lnkComment);
            this.pnlBody.Controls.Add(this.lnkShareAccount);
            this.pnlBody.Controls.Add(this.lnkSwitch);
            this.pnlBody.Controls.Add(this.lnkRefresh);
            this.pnlBody.Controls.Add(this.pnlEntries);
            this.pnlBody.Controls.Add(this.pnlContact);
            this.pnlBody.Controls.Add(this.lstEntries);
            this.pnlBody.Controls.Add(this.lstContacts);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 100);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(407, 399);
            this.pnlBody.TabIndex = 6;
            // 
            // lnkComment
            // 
            this.lnkComment.AutoSize = true;
            this.lnkComment.Location = new System.Drawing.Point(197, 2);
            this.lnkComment.Name = "lnkComment";
            this.lnkComment.Size = new System.Drawing.Size(67, 17);
            this.lnkComment.TabIndex = 9;
            this.lnkComment.TabStop = true;
            this.lnkComment.Text = "Comment";
            this.lnkComment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkComment_LinkClicked);
            // 
            // lnkShareAccount
            // 
            this.lnkShareAccount.AutoSize = true;
            this.lnkShareAccount.Location = new System.Drawing.Point(133, 2);
            this.lnkShareAccount.Name = "lnkShareAccount";
            this.lnkShareAccount.Size = new System.Drawing.Size(58, 17);
            this.lnkShareAccount.TabIndex = 8;
            this.lnkShareAccount.TabStop = true;
            this.lnkShareAccount.Text = "Share...";
            this.lnkShareAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShareAccount_LinkClicked);
            // 
            // lnkSwitch
            // 
            this.lnkSwitch.AutoSize = true;
            this.lnkSwitch.Location = new System.Drawing.Point(67, 2);
            this.lnkSwitch.Name = "lnkSwitch";
            this.lnkSwitch.Size = new System.Drawing.Size(60, 17);
            this.lnkSwitch.TabIndex = 7;
            this.lnkSwitch.TabStop = true;
            this.lnkSwitch.Text = "Switch...";
            this.lnkSwitch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSwitch_LinkClicked);
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Location = new System.Drawing.Point(3, 2);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(58, 17);
            this.lnkRefresh.TabIndex = 2;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "Refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // pnlEntries
            // 
            this.pnlEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEntries.Controls.Add(this.lnkVoidEntry);
            this.pnlEntries.Controls.Add(this.lnkAddEntry);
            this.pnlEntries.Location = new System.Drawing.Point(272, 2);
            this.pnlEntries.Name = "pnlEntries";
            this.pnlEntries.Size = new System.Drawing.Size(134, 19);
            this.pnlEntries.TabIndex = 4;
            // 
            // lnkVoidEntry
            // 
            this.lnkVoidEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkVoidEntry.AutoSize = true;
            this.lnkVoidEntry.Location = new System.Drawing.Point(44, 0);
            this.lnkVoidEntry.Name = "lnkVoidEntry";
            this.lnkVoidEntry.Size = new System.Drawing.Size(36, 17);
            this.lnkVoidEntry.TabIndex = 3;
            this.lnkVoidEntry.TabStop = true;
            this.lnkVoidEntry.Text = "Void";
            this.lnkVoidEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVoidEntry_LinkClicked);
            // 
            // lnkAddEntry
            // 
            this.lnkAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAddEntry.AutoSize = true;
            this.lnkAddEntry.Location = new System.Drawing.Point(86, 0);
            this.lnkAddEntry.Name = "lnkAddEntry";
            this.lnkAddEntry.Size = new System.Drawing.Size(45, 17);
            this.lnkAddEntry.TabIndex = 1;
            this.lnkAddEntry.TabStop = true;
            this.lnkAddEntry.Text = "Add...";
            this.lnkAddEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddEntry_LinkClicked);
            // 
            // pnlContact
            // 
            this.pnlContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContact.Controls.Add(this.lnkRemoveContact);
            this.pnlContact.Controls.Add(this.lnkAddContact);
            this.pnlContact.Location = new System.Drawing.Point(272, 2);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(134, 19);
            this.pnlContact.TabIndex = 5;
            // 
            // lnkRemoveContact
            // 
            this.lnkRemoveContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRemoveContact.AutoSize = true;
            this.lnkRemoveContact.Location = new System.Drawing.Point(20, 0);
            this.lnkRemoveContact.Name = "lnkRemoveContact";
            this.lnkRemoveContact.Size = new System.Drawing.Size(60, 17);
            this.lnkRemoveContact.TabIndex = 3;
            this.lnkRemoveContact.TabStop = true;
            this.lnkRemoveContact.Text = "Remove";
            this.lnkRemoveContact.Visible = false;
            this.lnkRemoveContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoveContact_LinkClicked);
            // 
            // lnkAddContact
            // 
            this.lnkAddContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAddContact.AutoSize = true;
            this.lnkAddContact.Location = new System.Drawing.Point(86, 0);
            this.lnkAddContact.Name = "lnkAddContact";
            this.lnkAddContact.Size = new System.Drawing.Size(45, 17);
            this.lnkAddContact.TabIndex = 1;
            this.lnkAddContact.TabStop = true;
            this.lnkAddContact.Text = "Add...";
            this.lnkAddContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddContact_LinkClicked);
            // 
            // lstEntries
            // 
            this.lstEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEntries.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEntries.FullRowSelect = true;
            this.lstEntries.GridLines = true;
            this.lstEntries.Location = new System.Drawing.Point(-1, 27);
            this.lstEntries.MultiSelect = false;
            this.lstEntries.Name = "lstEntries";
            this.lstEntries.Size = new System.Drawing.Size(407, 371);
            this.lstEntries.TabIndex = 0;
            this.lstEntries.UseCompatibleStateImageBehavior = false;
            this.lstEntries.View = System.Windows.Forms.View.Details;
            this.lstEntries.SelectedIndexChanged += new System.EventHandler(this.lstEntries_SelectedIndexChanged);
            // 
            // lstContacts
            // 
            this.lstContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContacts.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContacts.FullRowSelect = true;
            this.lstContacts.GridLines = true;
            this.lstContacts.Location = new System.Drawing.Point(-1, 27);
            this.lstContacts.MultiSelect = false;
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(407, 371);
            this.lstContacts.TabIndex = 6;
            this.lstContacts.UseCompatibleStateImageBehavior = false;
            this.lstContacts.View = System.Windows.Forms.View.Details;
            this.lstContacts.SelectedIndexChanged += new System.EventHandler(this.lstContacts_SelectedIndexChanged);
            // 
            // pnlCommand
            // 
            this.pnlCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommand.Controls.Add(this.txtNotes);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Location = new System.Drawing.Point(0, 499);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(407, 54);
            this.pnlCommand.TabIndex = 7;
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.txtNotes.Location = new System.Drawing.Point(0, 0);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Size = new System.Drawing.Size(405, 52);
            this.txtNotes.TabIndex = 2;
            // 
            // FEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 553);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlCommand);
            this.Name = "FEntries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{Account} - Intune";
            this.Load += new System.EventHandler(this.FEntries_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlEntries.ResumeLayout(false);
            this.pnlEntries.PerformLayout();
            this.pnlContact.ResumeLayout(false);
            this.pnlContact.PerformLayout();
            this.pnlCommand.ResumeLayout(false);
            this.pnlCommand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.ListView lstEntries;
        private System.Windows.Forms.LinkLabel lnkVoidEntry;
        private System.Windows.Forms.LinkLabel lnkRefresh;
        private System.Windows.Forms.LinkLabel lnkAddEntry;
        internal System.Windows.Forms.Panel pnlCommand;
        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.LinkLabel lnkRemoveContact;
        private System.Windows.Forms.LinkLabel lnkAddContact;
        private System.Windows.Forms.Panel pnlEntries;
        private System.Windows.Forms.ListView lstContacts;
        private System.Windows.Forms.LinkLabel lnkSwitch;
        private System.Windows.Forms.LinkLabel lnkShareAccount;
        private System.Windows.Forms.LinkLabel lnkComment;
        private System.Windows.Forms.TextBox txtNotes;
        internal System.Windows.Forms.Label lblHead;
    }
}