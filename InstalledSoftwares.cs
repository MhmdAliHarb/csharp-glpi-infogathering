using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopmutersController {
   public class InstalledSoftwares {
        public InstalledSoftwares( string name, string version ) {
            this.name = name;
            this.version = version;
        }
        public InstalledSoftwares() { }

        public string name { get; set; }
        public string version { get; set; }

        public List<InstalledSoftwares> GetInstalledSoftwares() {

            List<InstalledSoftwares > ls = new List<InstalledSoftwares>();

            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key);

            string displayName = string.Empty;
            string displayVersion = string.Empty;

            if ( key != null ) {
                foreach ( string subkey_name in key.GetSubKeyNames() ) {
                    RegistryKey subkey = key.OpenSubKey(subkey_name);

                    if ( subkey != null ) {
                        displayName = subkey.GetValue("DisplayName") as string;
                        displayVersion = subkey.GetValue("DisplayVersion") as string;
                    }
                    var softwares = new InstalledSoftwares(displayName, displayVersion);
                    ls.Add(softwares);
                }
            }
            return ls;
        }
    }
}
