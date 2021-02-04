namespace LimFTPClient
{
    partial class ParamsForm
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
            this.InputPanel = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.BufferTabPage = new System.Windows.Forms.TabPage();
            this.UsedTempSizeBox = new System.Windows.Forms.Label();
            this.UsedTempSizeLabel = new System.Windows.Forms.Label();
            this.MBLabel = new System.Windows.Forms.Label();
            this.TempSizeBox = new System.Windows.Forms.TextBox();
            this.TempSizeLabel = new System.Windows.Forms.Label();
            this.CleanBufferButton = new System.Windows.Forms.Button();
            this.InstallTabPage = new System.Windows.Forms.TabPage();
            this.OverwriteDirsBox = new System.Windows.Forms.CheckBox();
            this.RmPackageBox = new System.Windows.Forms.CheckBox();
            this.AutoInstallBox = new System.Windows.Forms.CheckBox();
            this.InstallPathLabel = new System.Windows.Forms.Label();
            this.CardInstallButton = new System.Windows.Forms.RadioButton();
            this.DeviceInstallButton = new System.Windows.Forms.RadioButton();
            this.DownloadTabPage = new System.Windows.Forms.TabPage();
            this.HttpServerButton = new System.Windows.Forms.RadioButton();
            this.FtpServerButton = new System.Windows.Forms.RadioButton();
            this.ServerTypeLabel = new System.Windows.Forms.Label();
            this.DownloadPathBox = new System.Windows.Forms.TextBox();
            this.DownloadPathLabel = new System.Windows.Forms.Label();
            this.OpenDirButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.BufferTabPage.SuspendLayout();
            this.InstallTabPage.SuspendLayout();
            this.DownloadTabPage.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // BufferTabPage
            // 
            this.BufferTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.BufferTabPage.Controls.Add(this.UsedTempSizeBox);
            this.BufferTabPage.Controls.Add(this.UsedTempSizeLabel);
            this.BufferTabPage.Controls.Add(this.MBLabel);
            this.BufferTabPage.Controls.Add(this.TempSizeBox);
            this.BufferTabPage.Controls.Add(this.TempSizeLabel);
            this.BufferTabPage.Controls.Add(this.CleanBufferButton);
            this.BufferTabPage.Location = new System.Drawing.Point(0, 0);
            this.BufferTabPage.Name = "BufferTabPage";
            this.BufferTabPage.Size = new System.Drawing.Size(232, 268);
            this.BufferTabPage.Text = "Хранилище";
            // 
            // UsedTempSizeBox
            // 
            this.UsedTempSizeBox.Location = new System.Drawing.Point(101, 40);
            this.UsedTempSizeBox.Name = "UsedTempSizeBox";
            this.UsedTempSizeBox.Size = new System.Drawing.Size(104, 20);
            this.UsedTempSizeBox.Text = "0 МБ";
            // 
            // UsedTempSizeLabel
            // 
            this.UsedTempSizeLabel.Location = new System.Drawing.Point(7, 39);
            this.UsedTempSizeLabel.Name = "UsedTempSizeLabel";
            this.UsedTempSizeLabel.Size = new System.Drawing.Size(116, 21);
            this.UsedTempSizeLabel.Text = "Занято сейчас:";
            // 
            // MBLabel
            // 
            this.MBLabel.Location = new System.Drawing.Point(180, 17);
            this.MBLabel.Name = "MBLabel";
            this.MBLabel.Size = new System.Drawing.Size(25, 20);
            this.MBLabel.Text = "МБ";
            // 
            // TempSizeBox
            // 
            this.TempSizeBox.Location = new System.Drawing.Point(129, 14);
            this.TempSizeBox.Name = "TempSizeBox";
            this.TempSizeBox.Size = new System.Drawing.Size(45, 21);
            this.TempSizeBox.TabIndex = 10;
            // 
            // TempSizeLabel
            // 
            this.TempSizeLabel.Location = new System.Drawing.Point(7, 16);
            this.TempSizeLabel.Name = "TempSizeLabel";
            this.TempSizeLabel.Size = new System.Drawing.Size(116, 21);
            this.TempSizeLabel.Text = "Размер хранилища:";
            // 
            // CleanBufferButton
            // 
            this.CleanBufferButton.Location = new System.Drawing.Point(7, 63);
            this.CleanBufferButton.Name = "CleanBufferButton";
            this.CleanBufferButton.Size = new System.Drawing.Size(79, 21);
            this.CleanBufferButton.TabIndex = 8;
            this.CleanBufferButton.Text = "Очистить";
            this.CleanBufferButton.Click += new System.EventHandler(this.CleanBufferButton_Click);
            // 
            // InstallTabPage
            // 
            this.InstallTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.InstallTabPage.Controls.Add(this.OverwriteDirsBox);
            this.InstallTabPage.Controls.Add(this.RmPackageBox);
            this.InstallTabPage.Controls.Add(this.AutoInstallBox);
            this.InstallTabPage.Controls.Add(this.InstallPathLabel);
            this.InstallTabPage.Controls.Add(this.CardInstallButton);
            this.InstallTabPage.Controls.Add(this.DeviceInstallButton);
            this.InstallTabPage.Location = new System.Drawing.Point(0, 0);
            this.InstallTabPage.Name = "InstallTabPage";
            this.InstallTabPage.Size = new System.Drawing.Size(240, 271);
            this.InstallTabPage.Text = "Установка";
            // 
            // OverwriteDirsBox
            // 
            this.OverwriteDirsBox.Location = new System.Drawing.Point(7, 14);
            this.OverwriteDirsBox.Name = "OverwriteDirsBox";
            this.OverwriteDirsBox.Size = new System.Drawing.Size(223, 20);
            this.OverwriteDirsBox.TabIndex = 6;
            this.OverwriteDirsBox.Text = "Перезапись файлов";
            // 
            // RmPackageBox
            // 
            this.RmPackageBox.Location = new System.Drawing.Point(7, 40);
            this.RmPackageBox.Name = "RmPackageBox";
            this.RmPackageBox.Size = new System.Drawing.Size(223, 20);
            this.RmPackageBox.TabIndex = 7;
            this.RmPackageBox.Text = "Удаление пакета";
            // 
            // AutoInstallBox
            // 
            this.AutoInstallBox.Location = new System.Drawing.Point(7, 66);
            this.AutoInstallBox.Name = "AutoInstallBox";
            this.AutoInstallBox.Size = new System.Drawing.Size(223, 20);
            this.AutoInstallBox.TabIndex = 8;
            this.AutoInstallBox.Text = "Установка после загрузки";
            // 
            // InstallPathLabel
            // 
            this.InstallPathLabel.Location = new System.Drawing.Point(7, 94);
            this.InstallPathLabel.Name = "InstallPathLabel";
            this.InstallPathLabel.Size = new System.Drawing.Size(100, 20);
            this.InstallPathLabel.Text = "Место установки";
            // 
            // CardInstallButton
            // 
            this.CardInstallButton.Location = new System.Drawing.Point(7, 143);
            this.CardInstallButton.Name = "CardInstallButton";
            this.CardInstallButton.Size = new System.Drawing.Size(100, 20);
            this.CardInstallButton.TabIndex = 5;
            this.CardInstallButton.Text = "SD Card";
            // 
            // DeviceInstallButton
            // 
            this.DeviceInstallButton.Location = new System.Drawing.Point(7, 117);
            this.DeviceInstallButton.Name = "DeviceInstallButton";
            this.DeviceInstallButton.Size = new System.Drawing.Size(100, 20);
            this.DeviceInstallButton.TabIndex = 4;
            this.DeviceInstallButton.Text = "Устройство";
            // 
            // DownloadTabPage
            // 
            this.DownloadTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.DownloadTabPage.Controls.Add(this.HttpServerButton);
            this.DownloadTabPage.Controls.Add(this.FtpServerButton);
            this.DownloadTabPage.Controls.Add(this.ServerTypeLabel);
            this.DownloadTabPage.Controls.Add(this.DownloadPathBox);
            this.DownloadTabPage.Controls.Add(this.DownloadPathLabel);
            this.DownloadTabPage.Controls.Add(this.OpenDirButton);
            this.DownloadTabPage.Location = new System.Drawing.Point(0, 0);
            this.DownloadTabPage.Name = "DownloadTabPage";
            this.DownloadTabPage.Size = new System.Drawing.Size(240, 271);
            this.DownloadTabPage.Text = "Загрузка";
            // 
            // HttpServerButton
            // 
            this.HttpServerButton.Enabled = false;
            this.HttpServerButton.Location = new System.Drawing.Point(7, 63);
            this.HttpServerButton.Name = "HttpServerButton";
            this.HttpServerButton.Size = new System.Drawing.Size(100, 20);
            this.HttpServerButton.TabIndex = 10;
            this.HttpServerButton.Text = "HTTP сервер";
            // 
            // FtpServerButton
            // 
            this.FtpServerButton.Checked = true;
            this.FtpServerButton.Location = new System.Drawing.Point(7, 37);
            this.FtpServerButton.Name = "FtpServerButton";
            this.FtpServerButton.Size = new System.Drawing.Size(100, 20);
            this.FtpServerButton.TabIndex = 9;
            this.FtpServerButton.Text = "FTP сервер";
            // 
            // ServerTypeLabel
            // 
            this.ServerTypeLabel.Location = new System.Drawing.Point(7, 14);
            this.ServerTypeLabel.Name = "ServerTypeLabel";
            this.ServerTypeLabel.Size = new System.Drawing.Size(226, 20);
            this.ServerTypeLabel.Text = "Тип сервера";
            // 
            // DownloadPathBox
            // 
            this.DownloadPathBox.Location = new System.Drawing.Point(7, 115);
            this.DownloadPathBox.Name = "DownloadPathBox";
            this.DownloadPathBox.Size = new System.Drawing.Size(163, 21);
            this.DownloadPathBox.TabIndex = 6;
            this.DownloadPathBox.GotFocus += new System.EventHandler(this.DownloadPathBox_GotFocus);
            this.DownloadPathBox.LostFocus += new System.EventHandler(this.DownloadPathBox_LostFocus);
            // 
            // DownloadPathLabel
            // 
            this.DownloadPathLabel.Location = new System.Drawing.Point(7, 95);
            this.DownloadPathLabel.Name = "DownloadPathLabel";
            this.DownloadPathLabel.Size = new System.Drawing.Size(100, 20);
            this.DownloadPathLabel.Text = "Путь загрузки";
            // 
            // OpenDirButton
            // 
            this.OpenDirButton.Location = new System.Drawing.Point(176, 115);
            this.OpenDirButton.Name = "OpenDirButton";
            this.OpenDirButton.Size = new System.Drawing.Size(57, 21);
            this.OpenDirButton.TabIndex = 7;
            this.OpenDirButton.Text = "Обзор";
            this.OpenDirButton.Click += new System.EventHandler(this.OpenDirButton1_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.DownloadTabPage);
            this.TabControl.Controls.Add(this.InstallTabPage);
            this.TabControl.Controls.Add(this.BufferTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(240, 294);
            this.TabControl.TabIndex = 11;
            // 
            // ParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.TabControl);
            this.Name = "ParamsForm";
            this.Text = "Параметры";
            this.Load += new System.EventHandler(this.ParamsBox_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ParamsForm_Closing);
            this.BufferTabPage.ResumeLayout(false);
            this.InstallTabPage.ResumeLayout(false);
            this.DownloadTabPage.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel InputPanel;
        private System.Windows.Forms.TabPage BufferTabPage;
        private System.Windows.Forms.TabPage InstallTabPage;
        private System.Windows.Forms.CheckBox OverwriteDirsBox;
        private System.Windows.Forms.CheckBox RmPackageBox;
        private System.Windows.Forms.CheckBox AutoInstallBox;
        private System.Windows.Forms.Label InstallPathLabel;
        private System.Windows.Forms.RadioButton CardInstallButton;
        private System.Windows.Forms.RadioButton DeviceInstallButton;
        private System.Windows.Forms.TabPage DownloadTabPage;
        private System.Windows.Forms.TextBox DownloadPathBox;
        private System.Windows.Forms.Label DownloadPathLabel;
        private System.Windows.Forms.Button OpenDirButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Label ServerTypeLabel;
        private System.Windows.Forms.RadioButton HttpServerButton;
        private System.Windows.Forms.RadioButton FtpServerButton;
        private System.Windows.Forms.TextBox TempSizeBox;
        private System.Windows.Forms.Label TempSizeLabel;
        private System.Windows.Forms.Label MBLabel;
        private System.Windows.Forms.Button CleanBufferButton;
        private System.Windows.Forms.Label UsedTempSizeBox;
        private System.Windows.Forms.Label UsedTempSizeLabel;
    }
}