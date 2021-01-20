namespace LimFTPClient
{
    partial class ParamsForm
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
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.OpenDirButton = new System.Windows.Forms.Button();
            this.DownloadPathBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(81, 236);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(77, 20);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.Location = new System.Drawing.Point(5, 122);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(100, 20);
            this.PathLabel.Text = "Путь загрузки";
            // 
            // OpenDirButton
            // 
            this.OpenDirButton.Location = new System.Drawing.Point(178, 144);
            this.OpenDirButton.Name = "OpenDirButton";
            this.OpenDirButton.Size = new System.Drawing.Size(57, 21);
            this.OpenDirButton.TabIndex = 6;
            this.OpenDirButton.Text = "Обзор";
            this.OpenDirButton.Click += new System.EventHandler(this.OpenDirButton_Click);
            // 
            // DownloadPathBox
            // 
            this.DownloadPathBox.Location = new System.Drawing.Point(5, 144);
            this.DownloadPathBox.Name = "DownloadPathBox";
            this.DownloadPathBox.Size = new System.Drawing.Size(167, 21);
            this.DownloadPathBox.TabIndex = 5;
            // 
            // ParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.OpenDirButton);
            this.Controls.Add(this.DownloadPathBox);
            this.Menu = this.MainMenu;
            this.Name = "ParamsForm";
            this.Text = "Параметры";
            this.Load += new System.EventHandler(this.ParamsBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Button OpenDirButton;
        private System.Windows.Forms.TextBox DownloadPathBox;
    }
}