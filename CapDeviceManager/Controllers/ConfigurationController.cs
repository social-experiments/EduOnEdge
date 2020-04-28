using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CapDeviceManager.Models;

namespace CapDeviceManager.Controllers
{
    public class ConfigurationController : Controller
    {
        public IActionResult Index(String connectionString)
        {
            var configurationViewModel = new ConfigurationViewModel() { ConnectionString = connectionString };
            return View(configurationViewModel);
        }
    }
}