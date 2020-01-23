using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Controllers
{
    public class NetworkController : Controller
    {
        private readonly ILogger<NetworkController> _logger;
        private readonly INetworkRepository networkRepository;

        public NetworkController(ILogger<NetworkController> logger, INetworkRepository networkRepository)
        {
            this._logger = logger;
            this.networkRepository = networkRepository;
        }

        [HttpGet]
        public IActionResult Check()
        {
            var networkModel = networkRepository.GetNetworkStatus();
            return View(networkModel);
        }
    }
}
