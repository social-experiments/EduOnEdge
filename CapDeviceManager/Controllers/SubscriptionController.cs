using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Select()
        {
            var accessToken = accessTokenRepository.GetAccessTokenModel();

            var subscriptions = subscriptionRepository.GetSubscriptionModels();

            IList<SelectListItem> selectListItems = new List<SelectListItem>();
            var subscriptionViewModel = new SubscriptionViewModel() { SubscriptionId = "", Subscriptions = selectListItems };
            if (subscriptions.Count > 0)
            {
                foreach (var subscription in subscriptions)
                {
                    selectListItems.Add(new SelectListItem { Value = subscription.Id, Text = subscription.Name });
                }
                selectListItems[0].Selected = true;
                subscriptionViewModel.SubscriptionId = subscriptions[0].Id;
            }
            return View(subscriptionViewModel);
        }

        [HttpPost]
        public IActionResult Select(string subscriptionId)
        {
            var accessToken = accessTokenRepository.GetAccessTokenModel();

            var subscriptions = subscriptionRepository.GetSubscriptionModels();
            foreach (var subscription in subscriptions)
            {
                if (subscription.Id == subscriptionId)
                {
                    bool result = subscriptionRepository.SelectSubscription(subscription.Id);
                    if (result)
                        return RedirectToAction("Select", "IoTHub");
                }
            }

            return RedirectToAction("Select", "Subscription");
        }
    }
}
