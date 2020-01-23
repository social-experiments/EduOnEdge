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
    public class ResourceGroupController : Controller
    {
        private readonly ILogger<ResourceGroupController> _logger;
        private ISubscriptionRepository subscriptionRepository;
        private IAccessTokenRepository accessTokenRepository;
        private IResourceGroupRepository resourceGroupRepository;

        public ResourceGroupController(ILogger<ResourceGroupController> logger, ISubscriptionRepository subscriptionRepository, IAccessTokenRepository accessTokenRepository, IResourceGroupRepository resourceGroupRepository)
        {
            _logger = logger;
            this.subscriptionRepository = subscriptionRepository;
            this.accessTokenRepository = accessTokenRepository;
            this.resourceGroupRepository = resourceGroupRepository;
        }

        [HttpGet]
        public IActionResult Select()
        {
            SubscriptionModel model = subscriptionRepository.GetSubscription();
            IList<ResourceGroupModel> rgModels = resourceGroupRepository.GetResourceGroupModels();

            IList<SelectListItem> selectListItems = new List<SelectListItem>();
            var rgViewModel = new ResourceGroupViewModel() { ResourceGroupName = "", ResourceGroups = selectListItems };

            if (rgModels.Count > 0)
            {
                foreach (var rgModel in rgModels)
                {
                    selectListItems.Add(new SelectListItem { Value = rgModel.Name, Text = rgModel.Name + ":" + rgModel.Location });
                }
                selectListItems[0].Selected = true;
                rgViewModel.ResourceGroupName = rgModels[0].Name;
            }
            return View(rgViewModel);
        }

        [HttpPost]
        public IActionResult Select(string resourceGroupName)
        {
            var accessToken = accessTokenRepository.GetAccessTokenModel();
            return View();
        }
    }
}
