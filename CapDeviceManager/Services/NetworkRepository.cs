using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CapDeviceManager.Services
{
    public class NetworkRepository : INetworkRepository
    {
        public NetworkModel GetNetworkStatus()
        {
            NetworkModel result = new NetworkModel(NetworkStatus.Disconnected, "0.0.0.0");

            try
            {
                // order interfaces by speed and filter out down and loopback
                // take first of the remaining
                var firstUpInterface = NetworkInterface.GetAllNetworkInterfaces()
                    .OrderByDescending(c => c.Speed)
                    .FirstOrDefault(c => c.NetworkInterfaceType != NetworkInterfaceType.Loopback && c.OperationalStatus == OperationalStatus.Up);
                if (firstUpInterface != null)
                {
                    var props = firstUpInterface.GetIPProperties();
                    // get first IPV4 address assigned to this interface
                    var firstIpV4Address = props.UnicastAddresses
                        .Where(c => c.Address.AddressFamily == AddressFamily.InterNetwork)
                        .Select(c => c.Address)
                        .FirstOrDefault();

                    result = new NetworkModel(NetworkStatus.Connected, firstIpV4Address.ToString());
                }
                return result;
            }
            catch (Exception exc)
            {
                //TODO: Handle Exception Here
                return null;
            }
        }
    }
}
