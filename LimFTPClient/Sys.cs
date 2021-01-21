using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace LimFTPClient
{
    class Sys
    {
        public static List<string> GetInstalledApps()
        {
            string SoftwareKey = "Software\\Apps";
            List<string> AppsList = new List<string>();

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {

                foreach (string appname in RegKey.GetSubKeyNames())
                {
                    if (appname != "Shared" && appname != "Microsoft Application Installer")
                    {
                        //InstalledBox.Items.Add(appname);
                        AppsList.Add(appname);
                    }
                }
            }

            return AppsList;
        }
    }
}
