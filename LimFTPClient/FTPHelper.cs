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
        /// <summary>
        /// Retrieves a file from the FTP server
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="DownloadDir"></param>
        /// <param name="FileName"></param>
        static public void DownloadFile(Uri URI, string DownloadDir, string FileName)
        {
            FTP Ftp = new FTP(URI.Host, URI.Port);

            try
            {
                Ftp.BeginConnect(URI.UserInfo, "");

                Ftp.ChangeDirectory(URI.AbsolutePath);

                Ftp.GetFile(FileName, DownloadDir + "\\" + FileName, true);
            }
            catch
            {
                Ftp.Disconnect();
                throw;
            }

            Ftp.Disconnect();
        }

        /// <summary>
        /// Retrieves a package information from the FTP server
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="AppName"></param>
        /// <returns>The file info as a string</returns> 
        static public string LoadInfo(Uri URI, string AppName)
        {   
            /*
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
             */

            FTP Ftp = new FTP(URI.Host, URI.Port);
            string FileName = AppName + ".zip";
            string FileSize;

            try
            {
                Ftp.BeginConnect(URI.UserInfo, "");

                Ftp.ChangeDirectory(URI.AbsolutePath);
            }
            catch
            {
                Ftp.Disconnect();
                throw;
            }

            try
            {
                FileSize = Ftp.GetFileSize(FileName);
                FileSize = ParamsHelper.BytesToMegs((ulong)Convert.ToInt64(FileSize)).ToString("0.##") + " МБ";
            }
            catch
            {
                Ftp.Disconnect();
                throw;
            }

            Ftp.Disconnect();

            return FileSize;
        }

        /// <summary>
        /// Retrieves the listing of the files in current directory on FTP server
        /// </summary>
        /// <param name="URI"></param>
        /// <returns>The server file list as a List</returns>
        static public void ReadListing(Uri URI)
        {
            FTP Ftp = new FTP(URI.Host, URI.Port);
            ParamsHelper.AppsList = new List<string>();
            string Listing;

            try
            {
                Ftp.BeginConnect(URI.UserInfo, "");

                Ftp.ChangeDirectory(URI.AbsolutePath);
            }
            catch
            {
                Ftp.Disconnect();
                throw;
            }

            try
            {
                Listing = Ftp.GetFileList(false);
            }
            catch
            {
                Listing = "";
                Ftp.Disconnect();
                throw;
            }

            string[] Files = Listing.Replace("\n", "").Split('\r');

            foreach (string file in Files)
            {
                if (!String.IsNullOrEmpty(file) && file.IndexOf('.') == -1)
                {
                    ParamsHelper.AppsList.Add(file.Replace("_", " "));
                }
            }

            if (ParamsHelper.AppsList.Count == 0)
            {
                ParamsHelper.CurrentURI = ParamsHelper.ServerURI;
                throw new Exception("Repo is empty");
            }

            Ftp.Disconnect();

            ParamsHelper.ThreadEvent.Set();

            ParamsHelper.IsThreadAlive = false;

        }       
    }
}
