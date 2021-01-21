using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace LimFTPClient
{

    class IO
    {
        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
        out ulong lpFreeBytesAvailable,
        out ulong lpTotalNumberOfBytes,
        out ulong lpTotalNumberOfFreeBytes);

        public static ulong GetStorageSpace(string Path)
        {
            if (String.IsNullOrEmpty(Path))
            {
                throw new ArgumentNullException(Path);
            }

            ulong FreeBytes, dummy1, dummy2;

            if (GetDiskFreeSpaceEx(Path, out FreeBytes, out dummy1, out dummy2))
            {
                return FreeBytes;
            }
            else return 0;
        }

        //[DllImport("zlib.dll", SetLastError = true, CharSet = CharSet.Auto)]
        //static extern int uncompress (byte dest, ulong destLen, byte source, ulong sourceLen);

        public static void ExtractToDirectory(string CompressedFilePath, string ExtractedFilePath)
        {
            FileInfo fileToDecompress = new FileInfo(CompressedFilePath);

            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                //string currentFileName = fileToDecompress.FullName;
                string newFileName = ExtractedFilePath;

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (DeflateStream decompressionStream = new DeflateStream(originalFileStream, CompressionMode.Decompress))
                    {
                        //decompressionStream.CopyTo(decompressedFileStream);
                        CopyTo(decompressionStream, decompressedFileStream, 8192);
                        //Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                    }      
                }
            }
        }

        private static void CopyTo(Stream source, Stream destination, int bufferSize)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = source.Read(bytes, 0, bytes.Length)) != 0)
            {
                destination.Write(bytes, 0, cnt);
            }
        }

        static public void LoadParameters()
        {
            if (String.IsNullOrEmpty(ParamsHelper.ConfigPath))
            {
                ParamsHelper.ConfigPath = IO.GetConfigPath();
            }

            FileInfo ConfigFile = new FileInfo(ParamsHelper.ConfigPath);

            BinaryReader Reader = new BinaryReader(ConfigFile.OpenRead());

            ParamsHelper.DownloadPath = Reader.ReadString();

            Reader.Close();
        }

        static private string GetConfigPath()
        {
            return GetCurrentDirectory() + "\\Default.cfg";
        }

        static public string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        static public void SaveParameters()
        {
            if (String.IsNullOrEmpty(ParamsHelper.ConfigPath))
            {
                ParamsHelper.ConfigPath = IO.GetConfigPath();
            }

            FileInfo ConfigFile = new FileInfo(ParamsHelper.ConfigPath);

            if (!String.IsNullOrEmpty(ParamsHelper.DownloadPath))
            {
                BinaryWriter Writer;

                if (!File.Exists(ParamsHelper.ConfigPath))
                {
                    Writer = new BinaryWriter(ConfigFile.Open(FileMode.Create));
                }
                else Writer = new BinaryWriter(ConfigFile.Open(FileMode.Open));

                Writer.Write(ParamsHelper.DownloadPath);

                Writer.Close();
            }
        }

        static public void RemoveParameters()
        {
            if (String.IsNullOrEmpty(ParamsHelper.ConfigPath))
            {
                ParamsHelper.ConfigPath = IO.GetConfigPath();
            }

            File.Delete(ParamsHelper.ConfigPath);

        }
    }
}
