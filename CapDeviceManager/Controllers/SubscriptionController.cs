using CapDeviceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> _logger;
        private ISubscriptionRepository subscriptionRepository;
        private IAccessTokenRepository accessTokenRepository;
        public SubscriptionController(ILogger<SubscriptionController> logger, ISubscriptionRepository subscriptionRepository, IAccessTokenRepository accessTokenRepository)
        {
            _logger = logger;
            this.subscriptionRepository = subscriptionRepository;
            this.accessTokenRepository = accessTokenRepository;
        }

        public IActionResult Select()
        {
            var accessToken = accessTokenRepository.GetAccessTokenModel();

            var subscriptions = subscriptionRepository.GetSubscriptionModels();
            return View(subscriptions);
        }
    }
}
