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
    public class IoTHubController : Controller
    {
        private readonly ILogger<IoTHubController> _logger;
        private ISubscriptionRepository subscriptionRepository;
        private IAccessTokenRepository accessTokenRepository;
        private IIoTHubRepository ioTHubRepository;

        public IoTHubController(ILogger<IoTHubController> logger, ISubscriptionRepository subscriptionRepository, IAccessTokenRepository accessTokenRepository, IIoTHubRepository ioTHubRepository)
        {
            _logger = logger;
            this.subscriptionRepository = subscriptionRepository;
            this.accessTokenRepository = accessTokenRepository;
            this.ioTHubRepository = ioTHubRepository;
        }

        [HttpGet]
        public IActionResult Select()
        {
            SubscriptionModel model = subscriptionRepository.GetSubscription();
            IList<IoTHubModel> iotHubModels = ioTHubRepository.GetIoTHubModels();

            IList<SelectListItem> selectListItems = new List<SelectListItem>();
            var iotHubViewModel = new IoTHubViewModel() { IoTHubName = "", IoTHubs = selectListItems };
            if (iotHubModels.Count > 0)
            { 
                foreach (var iotHubModel in iotHubModels)
                {
                    selectListItems.Add(new SelectListItem { Value = iotHubModel.Name, Text = iotHubModel.Name + ":" + iotHubModel.Location });
                }
                selectListItems[0].Selected = true;
                iotHubViewModel.IoTHubName = iotHubModels[0].Name;
            }
            return View(iotHubViewModel);
        }

        [HttpPost]
        public IActionResult Select(string iotHubName)
        {
            var accessToken = accessTokenRepository.GetAccessTokenModel();
            return View();
        }
    }
}
