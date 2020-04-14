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
    public class IoTEdgeController : Controller
    {
        private readonly ILogger<IoTEdgeController> _logger;
        private ISubscriptionRepository subscriptionRepository;
        private IAccessTokenRepository accessTokenRepository;
        private IIoTEdgeRepository ioEdgeRepository;

        public IoTEdgeController(ILogger<IoTEdgeController> logger, IIoTEdgeRepository ioTEdgeRepository)
        {
            _logger = logger;
            this.ioEdgeRepository = ioEdgeRepository;
        }

        [HttpGet]
        public IActionResult Select( string iotHubName)
        {
            IList<SelectListItem> selectListItems = new List<SelectListItem>();
            var ioTEdgeViewModel = new IoTEdgeViewModel() { IoTEdgeName = "", IoTEdges = selectListItems };
            
            IList<IoTEdgeModel> iotEdgeModels = ioEdgeRepository.GetIoTEdgeModels(iotHubName);

            if (iotEdgeModels != null && iotEdgeModels.Count > 0)
            {
                foreach (var iotEdgeModel in iotEdgeModels)
                {
                    selectListItems.Add(new SelectListItem { Value = iotEdgeModel.DeviceId });
                }
            }
            
            return View(ioTEdgeViewModel);
        }
    }
}