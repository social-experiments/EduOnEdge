using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapDeviceManager.Utils;

namespace CapDeviceManager.Controllers
{
    public class IoTEdgeController : Controller
    {
        private readonly ILogger<IoTEdgeController> _logger;
        private ISubscriptionRepository subscriptionRepository;
        private IAccessTokenRepository accessTokenRepository;
        private IIoTEdgeRepository ioTEdgeRepository;
        private static string iotHubName;

        public IoTEdgeController(ILogger<IoTEdgeController> logger, IIoTEdgeRepository ioTEdgeRepository)
        {
            _logger = logger;
            this.ioTEdgeRepository = ioTEdgeRepository;
        }

        [HttpGet]
        public IActionResult Select( string iotHubName)
        {
            IoTEdgeController.iotHubName = iotHubName;
            IList<SelectListItem> selectListItems = new List<SelectListItem>();
            var ioTEdgeViewModel = new IoTEdgeViewModel() { IoTEdgeName = "", IoTEdges = selectListItems };
            
            IList<IoTEdgeModel> iotEdgeModels = ioTEdgeRepository.GetIoTEdgeModels(iotHubName);

            if (iotEdgeModels != null && iotEdgeModels.Count > 0)
            {
                foreach (var iotEdgeModel in iotEdgeModels)
                {
                    selectListItems.Add(new SelectListItem { Value = iotEdgeModel.DeviceId, Text = iotEdgeModel.DeviceId });
                }
            }
            
            return View(ioTEdgeViewModel);
        }

        [HttpPost]
        public IActionResult SelectPost(string iotEdgeName)
        {
            Console.WriteLine("hello!");
            // var accessToken = accessTokenRepository.GetAccessTokenModel();
            /*IList<SelectListItem> selectListItems = new List<SelectListItem>();
            var iotHubViewModel = new IoTHubViewModel() { IoTHubName = iotHubName, IoTHubs = selectListItems };*/
            //AzHelper.AzAddCAPDevice(iotHubName, deviceId);
            AzHelper.AzGetConnectionString(IoTEdgeController.iotHubName, iotEdgeName);
            Console.WriteLine(AzHelper.azOutput);

            // iotHubName = "phuong";

            return null;
        }
    }
}