using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class IoTEdgeModel
    {
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }
    }
}
