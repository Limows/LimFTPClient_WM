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
            AppsBox.DataSource = null;
            AppsBox.Items.Clear();
           
            try
            {
                //SystemsBox.Items.AddRange(FTP.ReadListing(Parameters.CurrentURI).ToArray());
                //AppsBox.Items.Add("Test");
                //AppsBox.Items.Add("Test2");
                //ConnectionStatusLabel.Text = "Подключено";

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
            ParamsHelper.SystemURI = new Uri(ParamsHelper.ServerURI.ToString() + "/WinMobile_2003");
            Connect();
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