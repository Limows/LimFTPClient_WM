using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace LimFTPClient
{
    class ParamsHelper
    {
        static public Uri ServerURI = new Uri("ftp://anon@limowski.xyz:2121");
        static public Uri CurrentURI;
        static public Uri SystemURI;
        static public Uri AppURI;
        static public string DownloadPath = "";
        static public string ConfigPath = "";

        static public double BytesToMegs(ulong Bytes)
        {
            return ((double)Bytes / 1024) / 1024;
        }

    }
}
