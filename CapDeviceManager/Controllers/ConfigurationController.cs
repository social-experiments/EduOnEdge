using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CapDeviceManager.Models;
using CapDeviceManager.Utils;

namespace CapDeviceManager.Controllers
{
    public class ConfigurationController : Controller
    {
        private static String connection;

        public IActionResult Index(String connectionString)
        {
            connection = connectionString;
            var configurationViewModel = new ConfigurationViewModel() { ConnectionString = connectionString };
            return View(configurationViewModel);
        }

        [HttpPost]
        public void RunScript()
        {
            Console.WriteLine("I'm in  runscript");
            BashHelper.BashHelloWorld(connection);
            Console.WriteLine(BashHelper.bashOutput);
        }
    }
}