using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using CapDeviceManager.Controllers;
using CapDeviceManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CapDeviceManager
{
    public class Program
    {
        public static void Main(string[] args)

        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    NetworkModel result = new NetworkModel(NetworkStatus.Disconnected, "0.0.0.0");

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
                            .Where(c => c.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            .Select(c => c.Address)
                            .FirstOrDefault();

                        string ip = firstIpV4Address.ToString();
                        webBuilder.UseStartup<Startup>().UseUrls("https://" +ip +":5001;http://"+ ip +":5000");
                    }
                    });
    }
}
