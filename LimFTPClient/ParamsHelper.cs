using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;

namespace LimFTPClient
{
    class ParamsHelper
    {   
        static public Uri ServerURI = new Uri("ftp://anon@limowski.xyz:2121");
        static public Uri CurrentURI;
        static public Uri SystemURI;
        static public Uri AppURI;
        static public string DownloadPath;
        static public string InstallPath;
        static public string ConfigPath;
        static public string TempPath;
        static public int OSVersion;
        static public List<string> AppsList;
        static public bool IsThreadAlive;
        static public bool IsThreadError;
        static public bool IsThreadWaiting;
        static public Exception ThreadException;
        static public string ThreadMessage;
        static public bool IsAutoInstall;
        static public bool IsRmPackage;
        static public bool IsOverwrite;
        static public bool IsUninstalling;
        static public ulong TempSize;

        /// <summary>
        /// Convert bytes to megabytes
        /// </summary>
        /// <param name="Bytes">Bytes</param>
        /// <returns>Megabytes</returns> 
        static public double BytesToMegs(ulong Bytes)
        {
            return ((double)Bytes / 1024) / 1024;
        }

        /// <summary>
        /// Convert megabytes to bytes
        /// </summary>
        /// <param name="Megs">Megs</param>
        /// <returns>Bytes</returns> 
        static public ulong MegsToBytes(double Megs)
        {
            return (ulong)(Megs * 1024 * 1024);
        }

    }
}
