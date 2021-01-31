using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace WinMobileNetCFExt
{
    public class IO
    {
        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
        out ulong lpFreeBytesAvailable,
        out ulong lpTotalNumberOfBytes,
        out ulong lpTotalNumberOfFreeBytes);

        /// <summary>
        /// Get storage space
        /// </summary>
        /// <param name="Path"></param>
        /// <returns>Current storage space</returns> 
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

        /// <summary>
        /// Get removable storage directory
        /// </summary>
        /// <returns>Path to removable storage</returns> 
        static public string GetRemovableStorageDirectory()
        {
            string removableStorageDirectory = null;

            WIN32_FIND_DATA findData = new WIN32_FIND_DATA();
            IntPtr handle = IntPtr.Zero;

            handle = FindFirstFlashCard(ref findData);

            if (handle != INVALID_HANDLE_VALUE)
            {
                do
                {
                    if (!string.IsNullOrEmpty(findData.cFileName))
                    {
                        removableStorageDirectory = findData.cFileName;
                        break;
                    }
                }
                while (FindNextFlashCard(handle, ref findData));
                FindClose(handle);
            }

            return removableStorageDirectory;
        }

        public static readonly IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        // The CharSet must match the CharSet of the corresponding PInvoke signature
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WIN32_FIND_DATA
        {
            public int dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwOID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public int dwLowDateTime;
            public int dwHighDateTime;
        };

        [DllImport("note_prj", EntryPoint = "FindFirstFlashCard")]
        public extern static IntPtr FindFirstFlashCard(ref WIN32_FIND_DATA findData);

        [DllImport("note_prj", EntryPoint = "FindNextFlashCard")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool FindNextFlashCard(IntPtr hFlashCard, ref WIN32_FIND_DATA findData);

        [DllImport("coredll")]
        public static extern bool FindClose(IntPtr hFindFile);
    }
}
