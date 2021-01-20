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
       
        static public void DownloadFile(Uri URI, string DownloadDir, string FileName)
        {

            FTP Ftp = new FTP(URI.Host, URI.Port);

            Ftp.BeginConnect(URI.UserInfo, "");

            Ftp.ChangeDirectory(URI.AbsolutePath);

            Ftp.GetFile(FileName, DownloadDir + "\\" + FileName, true);

            Ftp.Disconnect();

        }

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

        static public List<string> ReadListing(Uri URI)
        {

            FTP Ftp = new FTP(URI.Host, URI.Port);
            //Ftp.ResponseReceived += new FTPResponseHandler(m_ftp_ResponseReceived);
            //Ftp.Connected += new FTPConnectedHandler(
            Ftp.BeginConnect(URI.UserInfo, "");

            Ftp.ChangeDirectory(URI.AbsolutePath);

            List<string> SystemsList = new List<string>();

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
                    line = null;
                }

                if (line.IndexOf('.') == -1)
                {
                    SystemsList.Add(line);
                }
            }
            

            if (SystemsList.Count == 0)
            {
                ParamsHelper.CurrentURI = ParamsHelper.ServerURI;
                throw new Exception("Repo is empty");
            }

            Ftp.Disconnect();

            return SystemsList;
        }
        
    }
}
