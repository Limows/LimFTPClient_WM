using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace LimFTPClient
{
    class Sys
    {
        /// <summary>
        /// Get list of installed apps
        /// </summary>
        /// <returns>List of installed apps</returns> 
        public static List<string> GetInstalledApps()
        {
            string SoftwareKey = "Software\\Apps";
            List<string> AppsList = new List<string>();

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {

                foreach (string appname in RegKey.GetSubKeyNames())
                {
                    if (appname != "Shared" && appname != "Microsoft Application Installer" && appname != "Customization Tools")
                    {
                        //InstalledBox.Items.Add(appname);
                        AppsList.Add(appname);
                    }
                }
            }

            return AppsList;
        }

        public static string GetInstallDir(string AppName)
        {
            string SoftwareKey = "Software\\Apps\\" + AppName;
            //List<string> AppsList = new List<string>();
            string InstallDir;

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                InstallDir = Convert.ToString(RegKey.GetValue("InstallDir", ""));   
            }

            return InstallDir;
        }

        static public void AppInstall(string CabPath, string AppName)
        {
            string ConsoleArguments = "/delete 0 /noaskdest ";
            string InstallPath = ParamsHelper.InstallPath + "\\" + AppName;

            string SoftwareKey = "Software\\Apps\\Microsoft Application Installer";

            RegistryKey AppInstallerKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true);
            RegistryKey InstallKey = AppInstallerKey.CreateSubKey("Install");
            InstallKey.SetValue(CabPath, InstallPath);

            //Directory.CreateDirectory(InstallPath);
       
            Process InstallProc = new Process();
            InstallProc.StartInfo.FileName = "\\windows\\wceload.exe";

            InstallProc.StartInfo.Arguments = ConsoleArguments +"\"" + CabPath + "\"";

            InstallProc.Start();

            InstallProc.WaitForExit();

            InstallKey.DeleteValue(CabPath); 
        }
    }
}
