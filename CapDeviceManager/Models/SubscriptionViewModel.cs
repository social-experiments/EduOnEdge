using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class SubscriptionViewModel
    {
        public string SubscriptionId { get; set; }
        public IList<SelectListItem> Subscriptions { get; set; }
    }

  //{
  //  "cloudName": "AzureCloud",
  //  "id": "6c41da6c-2ea2-4390-bb4f-a9c5c0573907",
  //  "isDefault": false,
  //  "name": "Azure Free Trial",
  //  "state": "Enabled",
  //  "tenantId": "cd718841-d840-4586-8601-bd1637cbc936",
  //  "user": {
  //    "name": "ssomasundaram@live.com",
  //    "type": "user"
  //  }
  //},
}
