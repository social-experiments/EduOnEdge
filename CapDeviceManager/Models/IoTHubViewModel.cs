using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class IoTHubViewModel
    {
        public string IoTHubName { get; set; }
        public IList<SelectListItem> IoTHubs { get; set; }
    }
}
