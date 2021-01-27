using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace LimFTPClient
{
    public partial class AppForm : Form
    {
        private string AppName;

        public AppForm(string CurrentAppName)
        {
            InitializeComponent();

            AppName = CurrentAppName;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = AppName + ".zip";
            ParamsHelper.CurrentURI = ParamsHelper.AppURI;
            bool IsDownloaded = false;
            bool IsInstalled = false;

            if (!String.IsNullOrEmpty(ParamsHelper.DownloadPath))
            {
                StatusLabel.Text = "Загрузка в папку " + ParamsHelper.DownloadPath;

                try
                {   
                    FTPHelper.DownloadFile(ParamsHelper.CurrentURI, ParamsHelper.DownloadPath, FileName);

                    IsDownloaded = true;

                    DialogResult Result = MessageBox.Show("Установить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (Result == DialogResult.Yes)
                    {
                        try
                        {
                            string ExtractedPath = IO.ExtractToDirectory(ParamsHelper.DownloadPath + "\\" + FileName, ParamsHelper.DownloadPath + "\\" + AppName);

                            if (!String.IsNullOrEmpty(ParamsHelper.InstallPath))
                            {
                                IsInstalled = Sys.AppInstall(ExtractedPath, AppName, ParamsHelper.IsOverwrite);
                            }
                            else
                            {
                                MessageBox.Show("Отсутствует путь для установки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка при установке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        }
                    }

                }

                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Невозможно сохранить в " + ParamsHelper.DownloadPath + "\nВозможно программа должна быть\nзапущена от имени администратора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                catch (OpenNETCF.Net.Ftp.FTPException NewEx)
                {
                    if (NewEx.Message == "Method only valid with an open connection")
                    {
                        MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Невозможно сохранить в " + ParamsHelper.DownloadPath + "\nВыберите другую директорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                catch (System.Net.Sockets.SocketException)
                {
                    MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    if (IsDownloaded && IsInstalled) StatusLabel.Text = "Успешно установлено";
                    else
                    {
                        if (IsDownloaded) StatusLabel.Text = "Успешно загружено";
                        else StatusLabel.Text = "Загрузка не удалась";
                    }
                }

            }
            else
            {
                MessageBox.Show("Отсутствует путь для сохранения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

            ParamsHelper.CurrentURI = ParamsHelper.AppURI;
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            this.Text = AppName.Replace("_", " ");
            //string InfoFileName = AppName + ".info";
            NameLabel.Text = AppName.Replace("_", " ");
            StatusLabel.Text = "";

            ParamsHelper.CurrentURI = ParamsHelper.AppURI;

            //ThreadStart AppStarter = delegate { FTPHelper.ReadListing(ParamsHelper.CurrentURI); };
            //Thread ListingThread = new Thread(ListingStarter);
            //ListingThread.Start();
            //ParamsHelper.IsThreadAlive = true;

            try
            {
                //AboutAppBox.Text = FTPHelper.LoadInfo(ParamsHelper.CurrentURI);
                SizeLabel.Text = FTPHelper.LoadInfo(ParamsHelper.CurrentURI, AppName);
            }
            catch
            {
                SizeLabel.Text = "0 МБ";
            }

            AboutAppBox.Text = "Для этого приложения ещё нет описания";

            ParamsHelper.CurrentURI = ParamsHelper.AppURI;
        }

        private void AppForm_FormClosing(object sender, CancelEventArgs e)
        {
            ParamsHelper.CurrentURI = ParamsHelper.SystemURI;
            //MessageBox.Show(Parameters.CurrentURI.ToString());
        }

    }
}