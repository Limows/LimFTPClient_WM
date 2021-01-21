using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace LimFTPClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            try
            {
                IO.LoadParameters();
            }
            catch
            {
                IO.RemoveParameters();
            }

            PropMenuItem.Enabled = false;
            PropButton.Enabled = false;
            DeleteMenuItem.Enabled = false;
            DeleteButton.Enabled = false;
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для выбора приложения кликните по его названию в списке", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox NewAboutForm = new AboutBox();
            NewAboutForm.ShowDialog();
        }

        private void BackMenuItem_Click(object sender, EventArgs e)
        {
            Connect();

            GetAppsList();
        }

        private void ParamsMenuItem_Click(object sender, EventArgs e)
        {
            ParamsForm NewParamsBox = new ParamsForm();
            NewParamsBox.ShowDialog();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            IO.SaveParameters();
        }

        private void Connect()
        {
            //ConnectionStatusLabel.Text = "Подключение...";
            ParamsHelper.CurrentURI = ParamsHelper.SystemURI;
           
            try
            {
                List<string> AppsList = FTPHelper.ReadListing(ParamsHelper.CurrentURI);

                foreach (string app in AppsList)
                {
                    AppsBox.Items.Add(app);
                }
            }
            catch
            {
                //ConnectionStatusLabel.Text = "Подключение не удалось";
                MessageBox.Show("Не удалось подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }

        private void ConnectionStatusLabel_ParentChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int MajorOSVersion = Environment.OSVersion.Version.Major;

            if (MajorOSVersion == 4) ParamsHelper.OSVersion = "WinMobile_2003";
            else ParamsHelper.OSVersion = "WinMobile_5";

            ParamsHelper.SystemURI = new Uri(ParamsHelper.ServerURI.ToString() + "/" + ParamsHelper.OSVersion);

            Connect();

            GetAppsList();
        }

        private void GetAppsList()
        {   
            InstalledBox.DataSource = null;
            InstalledBox.Items.Clear();
            try
            {
                List<string> InstalledList = new List<string>();
                InstalledList = Sys.GetInstalledApps();

                foreach (string app in InstalledList)
                {
                    InstalledBox.Items.Add(app);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void SystemsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParamsHelper.AppURI = new Uri(ParamsHelper.CurrentURI.ToString() + "/" + AppsBox.Text);
            ParamsHelper.CurrentURI = ParamsHelper.AppURI;
            //MessageBox.Show(Parameters.CurrentURI.ToString());
            AppForm NewAppForm = new AppForm(AppsBox.Text);
            NewAppForm.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void PropButton_Click(object sender, EventArgs e)
        {

        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MemLabel.Text = ParamsHelper.BytesToMegs(IO.GetStorageSpace(ParamsHelper.DownloadPath)).ToString("0.##") + " МБ";
            }
            catch (ArgumentNullException)
            {
                MemLabel.Text = "0 байт";
            }
        }
    }
}