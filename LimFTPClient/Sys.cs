using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

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
    }
}
