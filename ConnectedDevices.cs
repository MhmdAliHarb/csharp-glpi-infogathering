using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopmutersController {
    public class ConnectedDevices {

        public ConnectedDevices(string name, string status, string manufacturer ) {
            this.name = name;
            this.status = status;
            this.manufacturer = manufacturer;
        }

        public string name;
        public string status;
        public string manufacturer;
        public string installDate;

    }
}
