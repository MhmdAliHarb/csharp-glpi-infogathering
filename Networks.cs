using System;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using Lextm.SharpSnmpLib.Messaging;
using Lextm.SharpSnmpLib;
using System.Net;

namespace CopmutersController {
    public class Networks {
        public void getNetworks() { // useful to get the ip address
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");

            ManagementObjectCollection queryResults = searcher.Get();

            foreach ( ManagementObject network in queryResults ) {
                Console.WriteLine($"IP Address: {network["IPAddress"]}");
                Console.WriteLine($"Description: {network["Description"]}");
                Console.WriteLine($"Caption: {network["Caption"]}");
                Console.WriteLine($"DNS domain: {network["AdapterType"]}");
            }
        }

        public void getNetworkInfoUsingAdapter() { //unuseful function
            Console.WriteLine("Starting WMI query for network adapters...");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");

            foreach ( ManagementObject queryObj in searcher.Get() ) {
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("Description: {0}", queryObj["Description"]);
                Console.WriteLine("Adapter Type: {0}", queryObj["AdapterType"]);
                Console.WriteLine("MAC Address: {0}", queryObj["MACAddress"]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        public void testNetwork() {
            bool NetworkUp = NetworkInterface.GetIsNetworkAvailable();

            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
           
            foreach ( NetworkInterface ni in networkInterfaces ) {
                if ( ni.OperationalStatus == OperationalStatus.Up ) {
                    Console.WriteLine("Name " + ni.Name);
                    Console.WriteLine("Description: " + ni.Description);
                    NetworkInterfaceType type = ni.NetworkInterfaceType;
                    Console.WriteLine("type:"+type.ToString());
                    

                }

                Console.WriteLine("");
            }

            if ( NetworkUp ) Console.WriteLine("connected successfully");
            else Console.WriteLine("no connection");
        }
        public void scanning() {
            Console.WriteLine("Listing network devices...");

            CaptureDeviceList devices = CaptureDeviceList.Instance;
            if ( devices.Count == 0 ) {
                Console.WriteLine("No devices found.");
                return;
            }

            foreach ( var device in devices ) {
                Console.WriteLine($"Device: {device.Description}");
            }

            Console.ReadKey();
        }
 
    }   
}
