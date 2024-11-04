using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopmutersController {
    internal class Printers {
        public string name;
        public string deviceId;
        public string status;
        public string model;
        private string prop = "Win32_Printer";

        public Printers() {
            ControlMethods cs = new ControlMethods();
            this.name = cs.GetWmiProperty(prop, "Name");
            this.status = cs.GetWmiProperty(prop, "Status");
            this.deviceId = cs.GetWmiProperty(prop, "DeviceID");
            this.model = cs.GetWmiProperty(prop, "Description");
            

        }
       
    }
}
