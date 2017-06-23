namespace Intune.Desktop
{
    partial class FMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblHead = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lnkComment = new System.Windows.Forms.LinkLabel();
            this.pnlContactsBar = new System.Windows.Forms.Panel();
            this.lnkInviteContact = new System.Windows.Forms.LinkLabel();
            this.lnkOpenContact = new System.Windows.Forms.LinkLabel();
            this.lnkNewContact = new System.Windows.Forms.LinkLabel();
            this.lnkSwitch = new System.Windows.Forms.LinkLabel();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.pnlAccountsBar = new System.Windows.Forms.Panel();
            this.lnkShareAccount = new System.Windows.Forms.LinkLabel();
            this.lnkOpenAccount = new System.Windows.Forms.LinkLabel();
            this.lnkNewAccount = new System.Windows.Forms.LinkLabel();
            this.lstAccounts = new System.Windows.Forms.ListView();
            this.lstContacts = new System.Windows.Forms.ListView();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.StatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlTitle.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlContactsBar.SuspendLayout();
            this.pnlAccountsBar.SuspendLayout();
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
            this.pnlTitle.TabIndex = 5;
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
            this.lblHead.TabIndex = 3;
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
            this.lblTitle.Text = "Please select the account you want to open and see the entries. Use <New> to crea" +
    "te new account.";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Controls.Add(this.lnkComment);
            this.pnlBody.Controls.Add(this.pnlContactsBar);
            this.pnlBody.Controls.Add(this.lnkSwitch);
            this.pnlBody.Controls.Add(this.lnkRefresh);
            this.pnlBody.Controls.Add(this.pnlAccountsBar);
            this.pnlBody.Controls.Add(this.lstAccounts);
            this.pnlBody.Controls.Add(this.lstContacts);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 100);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(407, 413);
            this.pnlBody.TabIndex = 3;
            // 
            // lnkComment
            // 
            this.lnkComment.AutoSize = true;
            this.lnkComment.Location = new System.Drawing.Point(133, 3);
            this.lnkComment.Name = "lnkComment";
            this.lnkComment.Size = new System.Drawing.Size(67, 17);
            this.lnkComment.TabIndex = 7;
            this.lnkComment.TabStop = true;
            this.lnkComment.Text = "Comment";
            this.lnkComment.Visible = false;
            this.lnkComment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkComment_LinkClicked);
            // 
            // pnlContactsBar
            // 
            this.pnlContactsBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContactsBar.Controls.Add(this.lnkInviteContact);
            this.pnlContactsBar.Controls.Add(this.lnkOpenContact);
            this.pnlContactsBar.Controls.Add(this.lnkNewContact);
            this.pnlContactsBar.Location = new System.Drawing.Point(266, 0);
            this.pnlContactsBar.Name = "pnlContactsBar";
            this.pnlContactsBar.Size = new System.Drawing.Size(140, 22);
            this.pnlContactsBar.TabIndex = 5;
            // 
            // lnkInviteContact
            // 
            this.lnkInviteContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkInviteContact.AutoSize = true;
            this.lnkInviteContact.Location = new System.Drawing.Point(8, 3);
            this.lnkInviteContact.Name = "lnkInviteContact";
            this.lnkInviteContact.Size = new System.Drawing.Size(41, 17);
            this.lnkInviteContact.TabIndex = 4;
            this.lnkInviteContact.TabStop = true;
            this.lnkInviteContact.Text = "Invite";
            this.lnkInviteContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInviteContact_LinkClicked);
            // 
            // lnkOpenContact
            // 
            this.lnkOpenContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpenContact.AutoSize = true;
            this.lnkOpenContact.Location = new System.Drawing.Point(55, 3);
            this.lnkOpenContact.Name = "lnkOpenContact";
            this.lnkOpenContact.Size = new System.Drawing.Size(43, 17);
            this.lnkOpenContact.TabIndex = 3;
            this.lnkOpenContact.TabStop = true;
            this.lnkOpenContact.Text = "Open";
            this.lnkOpenContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenContact_LinkClicked);
            // 
            // lnkNewContact
            // 
            this.lnkNewContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkNewContact.AutoSize = true;
            this.lnkNewContact.Location = new System.Drawing.Point(99, 3);
            this.lnkNewContact.Name = "lnkNewContact";
            this.lnkNewContact.Size = new System.Drawing.Size(35, 17);
            this.lnkNewContact.TabIndex = 1;
            this.lnkNewContact.TabStop = true;
            this.lnkNewContact.Text = "New";
            this.lnkNewContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewContact_LinkClicked);
            // 
            // lnkSwitch
            // 
            this.lnkSwitch.AutoSize = true;
            this.lnkSwitch.Location = new System.Drawing.Point(67, 3);
            this.lnkSwitch.Name = "lnkSwitch";
            this.lnkSwitch.Size = new System.Drawing.Size(60, 17);
            this.lnkSwitch.TabIndex = 2;
            this.lnkSwitch.TabStop = true;
            this.lnkSwitch.Text = "Switch...";
            this.lnkSwitch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSwitch_LinkClicked);
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Location = new System.Drawing.Point(3, 3);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(58, 17);
            this.lnkRefresh.TabIndex = 2;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "Refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // pnlAccountsBar
            // 
            this.pnlAccountsBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAccountsBar.Controls.Add(this.lnkShareAccount);
            this.pnlAccountsBar.Controls.Add(this.lnkOpenAccount);
            this.pnlAccountsBar.Controls.Add(this.lnkNewAccount);
            this.pnlAccountsBar.Location = new System.Drawing.Point(266, 0);
            this.pnlAccountsBar.Name = "pnlAccountsBar";
            this.pnlAccountsBar.Size = new System.Drawing.Size(140, 22);
            this.pnlAccountsBar.TabIndex = 4;
            // 
            // lnkShareAccount
            // 
            this.lnkShareAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkShareAccount.AutoSize = true;
            this.lnkShareAccount.Location = new System.Drawing.Point(4, 3);
            this.lnkShareAccount.Name = "lnkShareAccount";
            this.lnkShareAccount.Size = new System.Drawing.Size(46, 17);
            this.lnkShareAccount.TabIndex = 4;
            this.lnkShareAccount.TabStop = true;
            this.lnkShareAccount.Text = "Share";
            this.lnkShareAccount.Visible = false;
            this.lnkShareAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShareAccount_LinkClicked);
            // 
            // lnkOpenAccount
            // 
            this.lnkOpenAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpenAccount.AutoSize = true;
            this.lnkOpenAccount.Location = new System.Drawing.Point(55, 3);
            this.lnkOpenAccount.Name = "lnkOpenAccount";
            this.lnkOpenAccount.Size = new System.Drawing.Size(43, 17);
            this.lnkOpenAccount.TabIndex = 3;
            this.lnkOpenAccount.TabStop = true;
            this.lnkOpenAccount.Text = "Open";
            this.lnkOpenAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenAccount_LinkClicked);
            // 
            // lnkNewAccount
            // 
            this.lnkNewAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkNewAccount.AutoSize = true;
            this.lnkNewAccount.Location = new System.Drawing.Point(99, 3);
            this.lnkNewAccount.Name = "lnkNewAccount";
            this.lnkNewAccount.Size = new System.Drawing.Size(35, 17);
            this.lnkNewAccount.TabIndex = 1;
            this.lnkNewAccount.TabStop = true;
            this.lnkNewAccount.Text = "New";
            this.lnkNewAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewAccount_LinkClicked);
            // 
            // lstAccounts
            // 
            this.lstAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAccounts.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAccounts.FullRowSelect = true;
            this.lstAccounts.GridLines = true;
            this.lstAccounts.Location = new System.Drawing.Point(-1, 26);
            this.lstAccounts.MultiSelect = false;
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(407, 386);
            this.lstAccounts.TabIndex = 0;
            this.lstAccounts.UseCompatibleStateImageBehavior = false;
            this.lstAccounts.View = System.Windows.Forms.View.Details;
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.lstAccounts_SelectedIndexChanged);
            this.lstAccounts.DoubleClick += new System.EventHandler(this.lstAccounts_DoubleClick);
            // 
            // lstContacts
            // 
            this.lstContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContacts.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContacts.FullRowSelect = true;
            this.lstContacts.GridLines = true;
            this.lstContacts.Location = new System.Drawing.Point(-1, 26);
            this.lstContacts.MultiSelect = false;
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(407, 386);
            this.lstContacts.TabIndex = 6;
            this.lstContacts.UseCompatibleStateImageBehavior = false;
            this.lstContacts.View = System.Windows.Forms.View.Details;
            this.lstContacts.SelectedIndexChanged += new System.EventHandler(this.lstContacts_SelectedIndexChanged);
            this.lstContacts.DoubleClick += new System.EventHandler(this.lstContacts_DoubleClick);
            // 
            // pnlCommand
            // 
            this.pnlCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommand.Controls.Add(this.btnOK);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Location = new System.Drawing.Point(0, 513);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(407, 40);
            this.pnlCommand.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(161, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // StatusImageList
            // 
            this.StatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImageList.ImageStream")));
            this.StatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImageList.Images.SetKeyName(0, "faviconRed.ico");
            this.StatusImageList.Images.SetKeyName(1, "faviconGreen.ico");
            this.StatusImageList.Images.SetKeyName(2, "faviconBlue.ico");
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 553);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlCommand);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts - Intune";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlContactsBar.ResumeLayout(false);
            this.pnlContactsBar.PerformLayout();
            this.pnlAccountsBar.ResumeLayout(false);
            this.pnlAccountsBar.PerformLayout();
            this.pnlCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Panel pnlBody;
        internal System.Windows.Forms.Panel pnlCommand;
        private System.Windows.Forms.LinkLabel lnkNewAccount;
        private System.Windows.Forms.ListView lstAccounts;
        private System.Windows.Forms.LinkLabel lnkRefresh;
        private System.Windows.Forms.LinkLabel lnkOpenAccount;
        private System.Windows.Forms.LinkLabel lnkSwitch;
        private System.Windows.Forms.Panel pnlAccountsBar;
        private System.Windows.Forms.Panel pnlContactsBar;
        private System.Windows.Forms.LinkLabel lnkOpenContact;
        private System.Windows.Forms.LinkLabel lnkNewContact;
        private System.Windows.Forms.ListView lstContacts;
        private System.Windows.Forms.LinkLabel lnkShareAccount;
        private System.Windows.Forms.LinkLabel lnkInviteContact;
        private System.Windows.Forms.LinkLabel lnkComment;
        internal System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList StatusImageList;
        internal System.Windows.Forms.Label lblHead;
    }
}