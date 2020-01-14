using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using CapDeviceManager.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CapDeviceManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILoginRepository loginRepository;

        public HomeController(ILogger<HomeController> logger, ILoginRepository loginRepository)
        {
            _logger = logger;
            this.loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            LoginModel loginModel = loginRepository.GetLoginModel();
            return View(loginModel);
        }
    }
}
