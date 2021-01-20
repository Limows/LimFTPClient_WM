﻿namespace LimFTPClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu MainMenu;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.ActionsMenuItem = new System.Windows.Forms.MenuItem();
            this.ParamsMenuItem = new System.Windows.Forms.MenuItem();
            this.BackMenuItem = new System.Windows.Forms.MenuItem();
            this.RefMenu = new System.Windows.Forms.MenuItem();
            this.HelpMenuItem = new System.Windows.Forms.MenuItem();
            this.AboutMenuItem = new System.Windows.Forms.MenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.NewPage = new System.Windows.Forms.TabPage();
            this.AppsBox = new System.Windows.Forms.ListBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InstalledPage = new System.Windows.Forms.TabPage();
            this.PropButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.MemLabel = new System.Windows.Forms.Label();
            this.FreeMemLabel = new System.Windows.Forms.Label();
            this.InstalledBox = new System.Windows.Forms.ListBox();
            this.InstalledLabel = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.NewPage.SuspendLayout();
            this.InstalledPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.ActionsMenuItem);
            this.MainMenu.MenuItems.Add(this.RefMenu);
            // 
            // ActionsMenuItem
            // 
            this.ActionsMenuItem.MenuItems.Add(this.ParamsMenuItem);
            this.ActionsMenuItem.MenuItems.Add(this.BackMenuItem);
            this.ActionsMenuItem.Text = "Действия";
            // 
            // ParamsMenuItem
            // 
            this.ParamsMenuItem.Text = "Параметры";
            this.ParamsMenuItem.Click += new System.EventHandler(this.ParamsMenuItem_Click);
            // 
            // BackMenuItem
            // 
            this.BackMenuItem.Text = "Назад";
            this.BackMenuItem.Click += new System.EventHandler(this.BackMenuItem_Click);
            // 
            // RefMenu
            // 
            this.RefMenu.MenuItems.Add(this.HelpMenuItem);
            this.RefMenu.MenuItems.Add(this.AboutMenuItem);
            this.RefMenu.Text = "Справка";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Text = "Помощь";
            this.HelpMenuItem.Click += new System.EventHandler(this.HelpMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Text = "О программе";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.NewPage);
            this.TabControl.Controls.Add(this.InstalledPage);
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(240, 268);
            this.TabControl.TabIndex = 7;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // NewPage
            // 
            this.NewPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.NewPage.Controls.Add(this.AppsBox);
            this.NewPage.Controls.Add(this.SearchBox);
            this.NewPage.Controls.Add(this.label1);
            this.NewPage.Location = new System.Drawing.Point(0, 0);
            this.NewPage.Name = "NewPage";
            this.NewPage.Size = new System.Drawing.Size(240, 245);
            this.NewPage.Text = "Приложения";
            // 
            // AppsBox
            // 
            this.AppsBox.Location = new System.Drawing.Point(0, 18);
            this.AppsBox.Name = "AppsBox";
            this.AppsBox.Size = new System.Drawing.Size(240, 198);
            this.AppsBox.TabIndex = 5;
            this.AppsBox.SelectedIndexChanged += new System.EventHandler(this.SystemsBox_SelectedIndexChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(3, 220);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(233, 21);
            this.SearchBox.TabIndex = 3;
            this.SearchBox.Text = "Поиск";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 17);
            this.label1.Text = "Выберите нужное приложение";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InstalledPage
            // 
            this.InstalledPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.InstalledPage.Controls.Add(this.InstalledLabel);
            this.InstalledPage.Controls.Add(this.PropButton);
            this.InstalledPage.Controls.Add(this.DeleteButton);
            this.InstalledPage.Controls.Add(this.MemLabel);
            this.InstalledPage.Controls.Add(this.FreeMemLabel);
            this.InstalledPage.Controls.Add(this.InstalledBox);
            this.InstalledPage.Location = new System.Drawing.Point(0, 0);
            this.InstalledPage.Name = "InstalledPage";
            this.InstalledPage.Size = new System.Drawing.Size(240, 245);
            this.InstalledPage.Text = "Установленные";
            // 
            // PropButton
            // 
            this.PropButton.Location = new System.Drawing.Point(83, 194);
            this.PropButton.Name = "PropButton";
            this.PropButton.Size = new System.Drawing.Size(72, 20);
            this.PropButton.TabIndex = 4;
            this.PropButton.Text = "Свойства";
            this.PropButton.Click += new System.EventHandler(this.PropButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(161, 194);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(72, 20);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MemLabel
            // 
            this.MemLabel.Location = new System.Drawing.Point(116, 224);
            this.MemLabel.Name = "MemLabel";
            this.MemLabel.Size = new System.Drawing.Size(100, 20);
            this.MemLabel.Text = "FreeMem";
            // 
            // FreeMemLabel
            // 
            this.FreeMemLabel.Location = new System.Drawing.Point(6, 224);
            this.FreeMemLabel.Name = "FreeMemLabel";
            this.FreeMemLabel.Size = new System.Drawing.Size(117, 20);
            this.FreeMemLabel.Text = "Доступно памяти:";
            // 
            // InstalledBox
            // 
            this.InstalledBox.Location = new System.Drawing.Point(0, 18);
            this.InstalledBox.Name = "InstalledBox";
            this.InstalledBox.Size = new System.Drawing.Size(240, 170);
            this.InstalledBox.TabIndex = 0;
            // 
            // InstalledLabel
            // 
            this.InstalledLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.InstalledLabel.Location = new System.Drawing.Point(0, 1);
            this.InstalledLabel.Name = "InstalledLabel";
            this.InstalledLabel.Size = new System.Drawing.Size(240, 17);
            this.InstalledLabel.Text = "Установленные приложения";
            this.InstalledLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "LimFTP Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.TabControl.ResumeLayout(false);
            this.NewPage.ResumeLayout(false);
            this.InstalledPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem ActionsMenuItem;
        private System.Windows.Forms.MenuItem RefMenu;
        private System.Windows.Forms.MenuItem ParamsMenuItem;
        private System.Windows.Forms.MenuItem BackMenuItem;
        private System.Windows.Forms.MenuItem HelpMenuItem;
        private System.Windows.Forms.MenuItem AboutMenuItem;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage NewPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage InstalledPage;
        private System.Windows.Forms.ListBox AppsBox;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label FreeMemLabel;
        private System.Windows.Forms.ListBox InstalledBox;
        private System.Windows.Forms.Label MemLabel;
        private System.Windows.Forms.Button PropButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label InstalledLabel;
    }
}

