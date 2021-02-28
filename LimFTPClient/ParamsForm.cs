using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinMobileNetCFExt.Forms;
using WinMobileNetCFExt;

namespace LimFTPClient
{
    public partial class ParamsForm : Form
    {
        public ParamsForm()
        {
            InitializeComponent();
        }

        private string CheckDirectory(string Path)
        {
            if (Directory.Exists(Path))
            {
                return Path;
            }
            else
            {
                DialogResult Result = MessageBox.Show("Такая директория не существует.\nСоздать?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                if (Result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(Path);
                        return Path;
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось создать директорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        return "";
                    }
                }
                else return "";
            }
        }

        private void OpenDirButton_Click(object sender, EventArgs e)
        {
            DownloadPathBox.Text = OpenDirDialog();
        }

        private string OpenDirDialog()
        {
            FolderBrowserDialog OpenDir = new FolderBrowserDialog();

            if (OpenDir.ShowDialog() == DialogResult.OK)
            {
                return OpenDir.SelectedPath;
            }
            else return "";
        }

        private void ParamsBox_Load(object sender, EventArgs e)
        {
            DownloadPathBox.Text = ParamsHelper.DownloadPath;
            OverwriteDirsBox.Checked = ParamsHelper.IsOverwrite;
            AutoInstallBox.Checked = ParamsHelper.IsAutoInstall;
            RmPackageBox.Checked = ParamsHelper.IsRmPackage;
            TempSizeBox.Text = ParamsHelper.BytesToMegs(ParamsHelper.TempSize).ToString("0.##");
            UsedTempSizeLabel.Text = "Занято сейчас: " + ParamsHelper.BytesToMegs(IOHelper.GetDirectorySize(ParamsHelper.TempPath)).ToString("0.###") + " МБ";

            List<string> StoragesNames = IO.GetAllRemovableStorages();

            if (!(StoragesNames.Count == 0))
            {
                int ButtonTop;
                int ButtonLeft;
                int ButtonWidth;

                if (this.Width == 480)
                {
                    ButtonTop = 303;
                    ButtonLeft = 14;
                    ButtonWidth = 400;
                }
                else
                {
                    ButtonTop = 140;
                    ButtonLeft = 7;
                    ButtonWidth = 200;
                }

                int i = 1;

                foreach (string storage in StoragesNames)
                {
                    RadioButton StorageButton = new RadioButton();

                    StorageButton.Left = ButtonLeft;
                    StorageButton.Top = ButtonTop;
                    StorageButton.Width = ButtonWidth;
                    StorageButton.Text = storage;
                    StorageButton.Name = "StorageButton" + i;
                    StorageButton.CheckedChanged += StorageButton_CheckedChanged;

                    if (!String.IsNullOrEmpty(ParamsHelper.InstallPath))
                    {
                        if (storage == ParamsHelper.InstallPath.Split('\\')[1])
                        {
                            StorageButton.Checked = true;
                        }
                    }

                    InstallTabPage.Controls.Add(StorageButton);

                    if (this.Width == 480)
                    {
                        ButtonTop += 46;
                    }
                    else
                    {
                        ButtonTop += 23;
                    }

                    i++;
                }
            }
            else
            {
                DeviceInstallButton.Checked = true;
            }
        }

        private void StorageButton_CheckedChanged(object sender, EventArgs e)
        {
            string DriveName;

            try
            {
                if (((RadioButton)sender).Checked)
                {
                    DriveName = ((RadioButton)sender).Text;
                    ParamsHelper.InstallPath = @"\" + DriveName + @"\Program Files";
                    DeviceInstallButton.Checked = false;
                }
            }
            catch
            {
                ParamsHelper.InstallPath = null;
            }
        }

        private void DownloadPathBox_GotFocus(object sender, EventArgs e)
        {
            InputPanel.Enabled = true;
        }

        private void DownloadPathBox_LostFocus(object sender, EventArgs e)
        {
            InputPanel.Enabled = false;
        }

        private void CleanBufferButton_Click(object sender, EventArgs e)
        {
            try
            {
                IOHelper.CleanBuffer();
                UsedTempSizeLabel.Text = "Занято сейчас: " + ParamsHelper.BytesToMegs(IOHelper.GetDirectorySize(ParamsHelper.TempPath)).ToString("0.###") + " МБ";
            }
            catch
            {

            }
        }

        private void ParamsForm_Closing(object sender, CancelEventArgs e)
        {
            ParamsHelper.DownloadPath = CheckDirectory(DownloadPathBox.Text);
            ParamsHelper.IsAutoInstall = AutoInstallBox.Checked;
            ParamsHelper.IsRmPackage = RmPackageBox.Checked;
            ParamsHelper.IsOverwrite = OverwriteDirsBox.Checked;

            if (String.IsNullOrEmpty(ParamsHelper.InstallPath))
            {
                MessageBox.Show("Выберите место для установки", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
                return;
            }
            else
            {
                try
                {
                    if (!Directory.Exists(ParamsHelper.InstallPath))
                    {
                        Directory.CreateDirectory(ParamsHelper.InstallPath);
                    }
                }
                catch
                {
                    MessageBox.Show("Выбранное устройство не готово", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }

            if (String.IsNullOrEmpty(ParamsHelper.DownloadPath))
            {
                MessageBox.Show("Путь не может быть пустым", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
                return;
            }

            if (String.IsNullOrEmpty(TempSizeBox.Text) || Convert.ToDouble(TempSizeBox.Text) == 0)
            {
                MessageBox.Show("Не задан размер хранилища", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
                return;
            }
            else
            {
                ParamsHelper.TempSize = ParamsHelper.MegsToBytes(Convert.ToDouble(TempSizeBox.Text));
            }

            e.Cancel = false;
        }

        private void DeviceInstallButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((RadioButton)sender).Checked)
                {
                    ParamsHelper.InstallPath = @"\Program Files";
                }
            }
            catch
            {
                ParamsHelper.InstallPath = null;
            }
        }

        private void TempSizeBox_GotFocus(object sender, EventArgs e)
        {
            InputPanel.Enabled = true;
        }

        private void TempSizeBox_LostFocus(object sender, EventArgs e)
        {
            InputPanel.Enabled = false;
        }
    }
}