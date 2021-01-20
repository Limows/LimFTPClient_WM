using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using OpenNETCF.Net.Ftp;
using System.IO;

namespace FTPTest
{
    public partial class Form1 : Form
    {
        delegate void StringDelegate(string value);

        private FTP m_ftp;

        public Form1()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            OnResponse("Connecting");
            m_ftp = new FTP("limowski.xyz", 2121);
            m_ftp.ResponseReceived += new FTPResponseHandler(m_ftp_ResponseReceived);
            m_ftp.Connected += new FTPConnectedHandler(m_ftp_Connected);
            m_ftp.BeginConnect(user.Text, password.Text);
        }

        void m_ftp_Connected(FTP source)
        {
            // when this happens we're ready to send command
            OnResponse("Connected.");
        }

        void m_ftp_ResponseReceived(FTP source, FTPResponse Response)
        {
            OnResponse(Response.Text);
        }

        private void OnResponse(string response)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StringDelegate(OnResponse), new object[] { response } );
                return;
            }
            ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), response });
            status.Items.Insert(0, item);
            status.Columns[1].Width = -1;
        }

        private void getFileList_Click(object sender, EventArgs e)
        {
            FTPFiles files = m_ftp.EnumFiles();

            fileList.Items.Clear();

            foreach (FTPFile file in files)
            {
                fileList.Items.Add( new ListViewItem( new string[] { file.Name, file.Size.ToString() } ));
            }

            tabs.SelectedIndex = 1;
        }

        private void upload_Click(object sender, EventArgs e)
        {
            FileStream stream = File.OpenRead("\\My Documents\\My Pictures\\Waterfall.jpg");
            m_ftp.SendFile(stream, "waterfall.jpg");
            stream.Close();
        }
    }
}