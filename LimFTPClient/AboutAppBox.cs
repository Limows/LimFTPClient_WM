﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace LimFTPClient
{
    public partial class AboutAppBox : Form
    {
        public AboutAppBox(string AppName)
        {
            InitializeComponent();

            this.Text = String.Format("О Программе");
            this.labelProductName.Text = AppName;
            //this.labelVersion.Text = String.Format("Версия {0}", AssemblyVersion);
            this.labelCompanyName.Text = String.Format("Автор: {0}", AppName.Split(' ')[0]);
            this.textBoxInstallPath.Text += Sys.GetInstallDir(AppName);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelCompanyName_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}