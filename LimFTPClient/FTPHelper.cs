using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using OpenNETCF.Net.Ftp;
using System.IO;

namespace LimFTPClient
{
    class FTPHelper
    {
        /*
        static public Stream CreateDownloadRequest(Uri URI)
        {   
            WebRequest FTPRequest = WebRequest.Create(URI);
            //FTPRequest.UseBinary = true;
            //FTPRequest.KeepAlive = false;
            //FTPRequest.Credentials = new NetworkCredential("anon", "");
            //FTPRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            WebResponse Response = FTPRequest.GetResponse();
            return Response.GetResponseStream();
        }
        */

        /*
        static public void DownloadFile(Uri URI, string FilePath)
        {

            //Stream FTPReader = CreateDownloadRequest(URI);
            FileStream outputStream;

            //FTPReader.Close();

            try
            {
                outputStream = new FileStream(FilePath, FileMode.Create);
            }
            catch
            {
                //FTPReader.Dispose();
                //FTPReader.Close();

                throw;
            }

            int bufferSize = 1024;
            int readCount;
            byte[] buffer = new byte[bufferSize];

            //readCount = FTPReader.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                outputStream.Write(buffer, 0, readCount);
                //readCount = FTPReader.Read(buffer, 0, bufferSize);
            }

            outputStream.Close();
            //FTPReader.Dispose();
            //FTPReader.Close();
        }
        */
        /*
        static public string LoadInfo(Uri URI)
        {
            Stream FTPReader = CreateDownloadRequest(URI);
            string AppInfo = "";
            int bufferSize = 1024;
            int readCount;
            byte[] buffer = new byte[bufferSize];

            readCount = FTPReader.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                AppInfo += Encoding.UTF8.GetString(buffer, 0, bufferSize);
                readCount = FTPReader.Read(buffer, 0, bufferSize);
            }

            FTPReader.Dispose();
            FTPReader.Close();

            return AppInfo;
        }
        */
        //static public Stream CreateListingRequest(Uri URI)
        //{

            //WebRequest FTPRequest = WebRequest.Create(URI);
            //FTPRequest.UseBinary = true;
            //FTPRequest.KeepAlive = false;
            //FTPRequest.Credentials = new NetworkCredential("anon", "");
            //FTPRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            //WebResponse Response = FTPRequest.GetResponse();

            //return Response.GetResponseStream();
        //}

        void FtpConnected(FTP source)
        {
            // when this happens we're ready to send command
            OnResponse("Connected.");
        }

        void FtpResponseReceived(FTP source, FTPResponse Response)
        {
            OnResponse(Response.Text);
        }

        private void OnResponse(string response)
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new StringDelegate(OnResponse), new object[] { response });
            //    return;
            //}
            //ListViewItem item = new ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), response });
            //status.Items.Insert(0, item);
            //status.Columns[1].Width = -1;
        }

        static public List<string> ReadListing(Uri URI)
        {
            //StreamReader FTPReader = new StreamReader(CreateListingRequest(URI));

            FTP Ftp = new FTP(URI.Host, URI.Port);
            //Ftp.ResponseReceived += new FTPResponseHandler(m_ftp_ResponseReceived);
            //Ftp.Connected += new FTPConnectedHandler(
            Ftp.BeginConnect(URI.UserInfo, "");

            Ftp.ChangeDirectory(URI.AbsolutePath);

            //Ftp.Connected();

            //Ftp.Connected += new FTPConnectedHandler(FtpConnected);

            List<string> SystemsList = new List<string>();
            
            //FTPFiles files = Ftp.GetFileList();

            string Listing = Ftp.GetFileList(false);

            string[] Files = Listing.Replace("\n", "").Split('\r');

            foreach (string file in Files)
            {
                string line;

                try
                {
                    line = file.Replace("_", " ");
                }
                catch
                {
                    line = "";
                }

                if (line.IndexOf('.') == -1)
                {
                    SystemsList.Add(line);
                }
            }
            

            //if (SystemsList.Count == 0)
            //{
            //    ParamsHelper.CurrentURI = ParamsHelper.ServerURI;
            //    throw new Exception("Repo is empty");
            //}

            Ftp.Disconnect();

            return SystemsList;
        }
        
    }
}
