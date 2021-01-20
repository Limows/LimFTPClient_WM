using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LimFTPClient
{
    public partial class ParamsForm : Form
    {
        public ParamsForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (DownloadPathBox.Text != "")
            {
                if (Directory.Exists(DownloadPathBox.Text))
                {
                    ParamsHelper.DownloadPath = DownloadPathBox.Text;
                    Close();
                }
                else
                {
                    DialogResult Result = MessageBox.Show("Такая папка не существует.\nСоздать?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    if (Result == DialogResult.Yes)
                    {
                        Directory.CreateDirectory(DownloadPathBox.Text);
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Путь не может быть пустым", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void OpenDirButton_Click(object sender, EventArgs e)
        {
            //FileDialog OpenDir = new OpenFileDialog();
            FolderBrowserDialog OpenDir = new FolderBrowserDialog();
            if (OpenDir.ShowDialog() == DialogResult.OK)
            {
                DownloadPathBox.Text = OpenDir.SelectedPath;
                //DownloadPathBox.Text = Path.GetDirectoryName(OpenDir.FileName);
            }

        }

        private void ParamsBox_Load(object sender, EventArgs e)
        {
            DownloadPathBox.Text = ParamsHelper.DownloadPath;
        }
    }
}