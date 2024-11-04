using System.Dynamic;
using System.Net.Http.Headers;

namespace CopmutersController {

    public class Computers {
        public string name;
        public string description;
        public string serial;
        public string manufacturer;
        public string model;
        public string type;
        public string OperatingSystem;
        public int computertypes_id;

        private string prop = "Win32_ComputerSystem";
        ControlMethods cs;

        public Computers() {
            cs = new ControlMethods();
            this.name = cs.GetWmiProperty(prop, "Name");
            this.description = cs.GetWmiProperty(prop, "Description");
            this.serial = cs.GetWmiProperty("Win32_BIOS", "SerialNumber");
            this.manufacturer = cs.GetWmiProperty(prop, "Manufacturer");
            this.model = cs.GetWmiProperty(prop, "Model");
            this.type = cs.getSystemType();
            this.computertypes_id = int.Parse(cs.GetWmiProperty(prop, "PcSystemType"));
            this.OperatingSystem = cs.getOs();
            
        }
       
       
        /* each class defines an asset to rertieve data from pc and send it seperated */


    }
}
