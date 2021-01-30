﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenNETCF.Net.Ftp;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace LimFTPClient
{
    class NetHelper
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

            Ftp.BeginConnect(URI.UserInfo, "");
            Ftp.ChangeDirectory(URI.AbsolutePath);
            Ftp.GetFile(FileName, DownloadDir + "\\" + FileName, true);

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

            Ftp.BeginConnect(URI.UserInfo, "");

            Ftp.ChangeDirectory(URI.AbsolutePath);
            FileSize = Ftp.GetFileSize(FileName);
            FileSize = ParamsHelper.BytesToMegs((ulong)Convert.ToInt64(FileSize)).ToString("0.##") + " МБ";

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

            Ftp.BeginConnect(URI.UserInfo, "");

            try
            {
                Ftp.ChangeDirectory(URI.AbsolutePath);
                Listing = Ftp.GetFileList(false);
            }
            catch(Exception NewEx)
            {
                Listing = "";
                ParamsHelper.IsThreadAlive = false;
                ParamsHelper.IsThreadError = true;
                ParamsHelper.ThreadException = NewEx;
                return;
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
                Ftp.Disconnect();
                ParamsHelper.IsThreadAlive = false;
                ParamsHelper.IsThreadError = true;
                ParamsHelper.ThreadException = new OpenNETCF.Net.Ftp.FTPException("Repository is empty");
                return;
            }

            Ftp.Disconnect();

            ParamsHelper.IsThreadAlive = false;

        }

        static public string CheckUpdates()
        {
            Uri URI = new Uri("http://limowski.xyz:80/LimFTPClientVersion.txt");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URI);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            string ResponseMessage;

            using (StreamReader stream = new StreamReader(Response.GetResponseStream(), Encoding.UTF8))
            {
                ResponseMessage = stream.ReadToEnd();
                ResponseMessage = ResponseMessage.Replace("\n", "");
            }

            return ResponseMessage;
        }

        static public string GetUpdates(string Version)
        {   
            Uri URI = new Uri("https://github.com/Limows/LimFTPClient_WM/releases/download/v" + Version + "/LimFTPClient.cab");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URI);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            string ResponseMessage;

            using (StreamReader stream = new StreamReader(Response.GetResponseStream(), Encoding.UTF8))
            {
                ResponseMessage = stream.ReadToEnd();
                ResponseMessage = ResponseMessage.Replace("\n", "");
            }

            return ResponseMessage;
        }

    }
}
