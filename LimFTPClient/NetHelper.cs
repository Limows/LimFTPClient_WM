using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetCFLibFTP;
using WinMobileNetCFExt;
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

            Ftp.Connect(URI.UserInfo, "");
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
            FTP Ftp = new FTP(URI.Host, URI.Port);
            string FileName = AppName + ".zip";
            string InfoName = AppName + ".info";
            string ScrShotName = AppName + ".png";
            string LogoName = "Logo.png";
            string FileSize;
            string BufferPath = IOHelper.GetCurrentDirectory() + "\\LocalFiles\\" + AppName;
            string AppInfo;

            if (!Directory.Exists(BufferPath)) Directory.CreateDirectory(BufferPath);

            Ftp.Connect(URI.UserInfo, "");

            try
            {
                Ftp.ChangeDirectory(URI.AbsolutePath);
                FileSize = Ftp.GetFileSize(FileName);
                FileSize = ParamsHelper.BytesToMegs((ulong)Convert.ToInt64(FileSize)).ToString("0.##") + " МБ";
            }
            catch
            {
                FileSize = null;
            }

            try
            {
                Ftp.GetFile(InfoName, BufferPath + "\\" + InfoName, true);
                InfoName = BufferPath + "\\" + InfoName;
            }
            catch
            {
                InfoName = null;
            }

            try
            {
                Ftp.GetFile(LogoName, BufferPath + "\\" + LogoName, true);
                LogoName = BufferPath + "\\" + LogoName;
            }
            catch
            {
                LogoName = null;
            }

            try
            {   
                Ftp.GetFile(ScrShotName, BufferPath + "\\" + ScrShotName, true);
                ScrShotName = BufferPath + "\\" + ScrShotName;
            }
            catch
            {
                ScrShotName = null;
            }

            AppInfo = FileSize + "\n" + InfoName + "\n" + LogoName + "\n" + ScrShotName;

            Ftp.Disconnect();

            return AppInfo;
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

            Ftp.Connect(URI.UserInfo, "");

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
                ParamsHelper.ThreadException = new NetCFLibFTP.FTPException("Repository is empty");
                return;
            }

            Ftp.Disconnect();

            ParamsHelper.IsThreadAlive = false;

        }

        static public string CheckUpdates()
        {
            Uri URI = new Uri("http://limowski.xyz:80/downloads/LimFTPClient/WinMobile/LimFTPClientVersion.txt");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URI);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            string ResponseMessage;

            try
            {

                using (StreamReader stream = new StreamReader(Response.GetResponseStream(), Encoding.UTF8))
                {
                    ResponseMessage = stream.ReadToEnd();
                    ResponseMessage = ResponseMessage.Replace("\n", "");
                }
            }
            catch(Exception NewEx)
            {
                ResponseMessage = NewEx.Message;
            }

            return ResponseMessage;
        }

        static public void GetUpdates(string Version)
        {
            Uri URI = new Uri("http://limowski.xyz:80/downloads/LimFTPClient/WinMobile/LimFTPClient.cab");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URI);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

            using (FileStream UpdateFile = new FileStream(ParamsHelper.DownloadPath + "\\Update.cab", FileMode.Create, FileAccess.Write))
            {
                using (BinaryReader Reader = new BinaryReader(Response.GetResponseStream()))
                {
                    int BufSize = 2048;
                    byte[] Buffer = new byte[BufSize];
                    int Count = 0;

                    while ((Count = Reader.Read(Buffer, 0, BufSize)) > 0)
                    {
                        UpdateFile.Write(Buffer, 0, Count);
                    }
                }
            }
        }

    }
}
