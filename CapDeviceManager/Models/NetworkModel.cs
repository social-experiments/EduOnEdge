using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public enum NetworkStatus
    {
        Connected,
        Disconnected
    }
    public class NetworkModel
    {
        public NetworkStatus NetworkStatus { get; set; }

        public string IPAdddress { get; set; }

        public NetworkModel(NetworkStatus status, string ipAddr)
        {
            NetworkStatus = status;
            IPAdddress = ipAddr;
        }
    }
}
