using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopmutersController {
    internal class Monitor {
        public string name;
        public string model;
        public string manfacturer;
        public string id;
        private string prop = "Win32_DesktopMonitor";

        public Monitor() {
           ControlMethods cs = new ControlMethods();
            this.name = cs.GetWmiProperty(prop, "Name");
            this.model = cs.GetWmiProperty(prop,"Description");
            this.manfacturer = cs.GetWmiProperty(prop, "MonitorManfacturer");
            this.id = cs.GetWmiProperty(prop, "SerialNumber");
        }
    }
}
