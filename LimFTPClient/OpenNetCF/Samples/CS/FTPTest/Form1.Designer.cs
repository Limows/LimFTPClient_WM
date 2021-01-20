namespace FTPTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.connect = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.getFileList = new System.Windows.Forms.MenuItem();
            this.upload = new System.Windows.Forms.MenuItem();
            this.server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabs = new System.Windows.Forms.TabControl();
            this.statusTab = new System.Windows.Forms.TabPage();
            this.status = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.fileTab = new System.Windows.Forms.TabPage();
            this.fileList = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.statusTab.SuspendLayout();
            this.fileTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.connect);
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // connect
            // 
            this.connect.Text = "Connect";
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.getFileList);
            this.menuItem1.MenuItems.Add(this.upload);
            this.menuItem1.Text = "Commands";
            // 
            // getFileList
            // 
            this.getFileList.Text = "Get File List";
            this.getFileList.Click += new System.EventHandler(this.getFileList_Click);
            // 
            // upload
            // 
            this.upload.Text = "Upload File";
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(63, 3);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(174, 21);
            this.server.TabIndex = 0;
            this.server.Text = "www.opennetcf.com";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.Text = "ftp://";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.Text = "user";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(63, 30);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(174, 21);
            this.user.TabIndex = 4;
            this.user.Text = "skyhook";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.Text = "pwd";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(63, 57);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(174, 21);
            this.password.TabIndex = 7;
            this.password.Text = "skyh00k";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabs);
            this.panel1.Location = new System.Drawing.Point(3, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 181);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.statusTab);
            this.tabs.Controls.Add(this.fileTab);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(234, 181);
            this.tabs.TabIndex = 0;
            // 
            // statusTab
            // 
            this.statusTab.Controls.Add(this.status);
            this.statusTab.Location = new System.Drawing.Point(0, 0);
            this.statusTab.Name = "statusTab";
            this.statusTab.Size = new System.Drawing.Size(234, 158);
            this.statusTab.Text = "Status";
            // 
            // status
            // 
            this.status.Columns.Add(this.columnHeader1);
            this.status.Columns.Add(this.columnHeader2);
            this.status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.status.Location = new System.Drawing.Point(0, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(234, 158);
            this.status.TabIndex = 0;
            this.status.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Response";
            this.columnHeader2.Width = 160;
            // 
            // fileTab
            // 
            this.fileTab.Controls.Add(this.fileList);
            this.fileTab.Location = new System.Drawing.Point(0, 0);
            this.fileTab.Name = "fileTab";
            this.fileTab.Size = new System.Drawing.Size(234, 158);
            this.fileTab.Text = "File List";
            // 
            // fileList
            // 
            this.fileList.Columns.Add(this.columnHeader3);
            this.fileList.Columns.Add(this.columnHeader4);
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.Location = new System.Drawing.Point(0, 0);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(234, 158);
            this.fileList.TabIndex = 1;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File Name";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 160;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.server);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.statusTab.ResumeLayout(false);
            this.fileTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.MenuItem connect;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem getFileList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage statusTab;
        private System.Windows.Forms.ListView status;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage fileTab;
        private System.Windows.Forms.MenuItem upload;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

