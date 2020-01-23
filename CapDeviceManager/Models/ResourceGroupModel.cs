using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class ResourceGroupModel
    {
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    //  C:\Users\sarsoma>az group list
    //  [
    //  {
    //  "id": "/subscriptions/6c41da6c-2ea2-4390-bb4f-a9c5c0573907/resourceGroups/MESC",
    //  "location": "westus",
    //  "managedBy": null,
    //  "name": "MESC",
    //  "properties": {
    //      "provisioningState": "Succeeded"
    //  },
    //  "tags": {}
    //  },
    //  {
    //  "id": "/subscriptions/6c41da6c-2ea2-4390-bb4f-a9c5c0573907/resourceGroups/IoTEdgeResources",
    //  "location": "westus2",
    //  "managedBy": null,
    //  "name": "IoTEdgeResources",
    //  "properties": {
    //      "provisioningState": "Succeeded"
    //  },
    //  "tags": null
    //  },
    //  {
    //  "id": "/subscriptions/6c41da6c-2ea2-4390-bb4f-a9c5c0573907/resourceGroups/NetworkWatcherRG",
    //  "location": "westus2",
    //  "managedBy": null,
    //  "name": "NetworkWatcherRG",
    //  "properties": {
    //      "provisioningState": "Succeeded"
    //  },
    //  "tags": null
    //  }
    //  ]
}
