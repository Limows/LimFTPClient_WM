using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;

namespace LimFTPClient
{
    class IOHelper
    {
        /// <summary>
        /// Extract zip archive to directory
        /// </summary>
        /// <param name="CompressedFilePath"></param>
        /// <param name="ExtractedFilePath"></param>
        /// <returns>Path to extracted archive</returns> 
        public static string ExtractToDirectory(string CompressedFilePath, string ExtractedFilePath)
        {   
            bool IsDirectory = false;

            ZipFile Archive = new ZipFile(CompressedFilePath);

            foreach (ZipEntry entry in Archive)
            {
                if (entry.IsDirectory)
                {
                    IsDirectory = true;
                    break;
                }
            }

            FastZip ZipArc = new FastZip();
            ZipArc.CreateEmptyDirectories = true;

            ZipArc.ExtractZip(CompressedFilePath, ExtractedFilePath, null);

            Archive.Close();

            if (IsDirectory)
            {   
                string [] Dirs = Directory.GetDirectories(ExtractedFilePath);
                return Dirs[0];
            }

            return ExtractedFilePath;
        }

        static public void LoadParameters()
        {
            if (String.IsNullOrEmpty(ParamsHelper.ConfigPath))
            {
                ParamsHelper.ConfigPath = IOHelper.GetConfigPath();
            }

            FileInfo ConfigFile = new FileInfo(ParamsHelper.ConfigPath);

            using (BinaryReader Reader = new BinaryReader(ConfigFile.OpenRead()))
            {
                ParamsHelper.IsOverwrite = Reader.ReadBoolean();
                ParamsHelper.IsRmPackage = Reader.ReadBoolean();
                ParamsHelper.IsAutoInstall = Reader.ReadBoolean();
                ParamsHelper.DownloadPath = Reader.ReadString();
                ParamsHelper.InstallPath = Reader.ReadString();
            }
        }

        static public string ReadTextFile(string Path)
        {
            FileInfo File = new FileInfo(Path);

            using (TextReader Reader = new StreamReader(File.OpenRead()))
            {
                return Reader.ReadToEnd();
            }
        }

        static public void CleanBuffer()
        {
            Directory.Delete(GetCurrentDirectory() + "\\LocalFiles", true);
        }

        static private string GetConfigPath()
        {
            return GetCurrentDirectory() + "\\Default.cfg";
        }

        /// <summary>
        /// Get current directory
        /// </summary>
        /// <returns>Current directory path</returns> 
        static public string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        static public void SaveParameters()
        {
            if (String.IsNullOrEmpty(ParamsHelper.ConfigPath))
            {
                ParamsHelper.ConfigPath = IOHelper.GetConfigPath();
            }

            FileInfo ConfigFile = new FileInfo(ParamsHelper.ConfigPath);

            if (!String.IsNullOrEmpty(ParamsHelper.DownloadPath) && !String.IsNullOrEmpty(ParamsHelper.InstallPath))
            {
                RemoveParameters();

                using (BinaryWriter Writer = new BinaryWriter(ConfigFile.Open(FileMode.Create)))
                {
                    Writer.Write(ParamsHelper.IsOverwrite);
                    Writer.Write(ParamsHelper.IsRmPackage);
                    Writer.Write(ParamsHelper.IsAutoInstall);
                    Writer.Write(ParamsHelper.DownloadPath);
                    Writer.Write(ParamsHelper.InstallPath);
                }
            }
        }

        static public void RemoveParameters()
        {
            if (String.IsNullOrEmpty(ParamsHelper.ConfigPath))
            {
                ParamsHelper.ConfigPath = IOHelper.GetConfigPath();
            }

            File.Delete(ParamsHelper.ConfigPath);

        }
    }
}
