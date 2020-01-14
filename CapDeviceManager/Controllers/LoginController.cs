using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace CapDeviceManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private ILoginRepository loginRepository;
        private IAccountRepository accountRepository;
        public LoginController(ILogger<LoginController> logger, ILoginRepository loginRepository, IAccountRepository accountRepository)
        {
            _logger = logger;
            this.loginRepository = loginRepository;
            this.accountRepository = accountRepository;
        }

        public IActionResult Confirm()
        {
            AccountModel accountModel = accountRepository.GetAccountModel();
            if (accountModel == null)
            {
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                return View(accountModel);
            }
        }

        public IActionResult SignIn()
        {
            LoginModel loginModel = loginRepository.GetLoginModel();
            return View(loginModel);
        }
    }
}
