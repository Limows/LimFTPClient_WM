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

            if (!String.IsNullOrEmpty(ParamsHelper.DownloadPath))
            {
                StatusLabel.Text = "Загрузка в папку " + ParamsHelper.DownloadPath;
                try
                {   
                    FTPHelper.DownloadFile(ParamsHelper.CurrentURI, ParamsHelper.DownloadPath, FileName);
                    StatusLabel.Text = "Успешно загружено";



                    DialogResult Result = MessageBox.Show("Распаковать пакет?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (Result == DialogResult.Yes)
                    {
                        try
                        {
                            //ZipFile.ExtractToDirectory(Parameters.DownloadPath + "\\" + FileName, Parameters.DownloadPath + "\\" + AppName);
                            IO.ExtractToDirectory(ParamsHelper.DownloadPath + "\\" + FileName, ParamsHelper.DownloadPath + "\\" + AppName);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка при распаковке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            File.Delete(ParamsHelper.DownloadPath + "\\" + AppName);
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
                    StatusLabel.Text = "Загрузка не удалась";
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

            try
            {
                //AboutAppBox.Text = FTPHelper.LoadInfo(ParamsHelper.CurrentURI);
                SizeLabel.Text = FTPHelper.LoadInfo(ParamsHelper.CurrentURI, AppName);
            }
            catch
            {
                AboutAppBox.Text = "Для этого приложения ещё нет описания";
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