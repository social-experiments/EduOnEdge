using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class IoTHubModel
    {
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

//C:\Users\sarsoma>az iot hub list
//[
//{
//"etag": "AAAAAAlq7xU=",
//    "id": "/subscriptions/6c41da6c-2ea2-4390-bb4f-a9c5c0573907/resourceGroups/IoTEdgeResources/providers/Microsoft.Devices/IotHubs/capedgeiothub",
//    "location": "westus2",
//    "name": "capedgeiothub",
//    "properties": {
//    "authorizationPolicies": null,
//        "cloudToDevice": {
//    "defaultTtlAsIso8601": "1:00:00",
//        "feedback": {
//        "lockDurationAsIso8601": "0:00:05",
//            "maxDeliveryCount": 10,
//            "ttlAsIso8601": "1:00:00"
//    },
//    "maxDeliveryCount": 10
//    },
//    "comments": null,
//    "enableFileUploadNotifications": false,
//    "eventHubEndpoints": {
//    "events": {
//        "endpoint": "sb://ihsuprodmwhres011dednamespace.servicebus.windows.net/",
//        "partitionCount": 2,
//        "partitionIds": [
//        "0",
//        "1"
//        ],
//        "path": "iothub-ehub-capedgeiot-2467736-fa360097a3",
//        "retentionTimeInDays": 1
//    },
//    "operationsMonitoringEvents": {
//        "endpoint": "sb://ihsuprodmwhres012dednamespace.servicebus.windows.net/",
//        "partitionCount": 2,
//        "partitionIds": [
//        "0",
//        "1"
//        ],
//        "path": "iothub-ehub-capedgeiot-2467736-b158d204b3",
//        "retentionTimeInDays": 1
//    }
//    },
//    "features": "None",
//    "hostName": "capedgeiothub.azure-devices.net",
//    "ipFilterRules": [],
//    "messagingEndpoints": {
//    "fileNotifications": {
//        "lockDurationAsIso8601": "0:01:00",
//        "maxDeliveryCount": 10,
//        "ttlAsIso8601": "1:00:00"
//    }
//    },
//    "operationsMonitoringProperties": {
//    "events": {
//        "C2DCommands": "None",
//        "Connections": "None",
//        "DeviceIdentityOperations": "None",
//        "DeviceTelemetry": "None",
//        "FileUploadOperations": "None",
//        "None": "None",
//        "Routes": "None"
//    }
//    },
//    "provisioningState": "Succeeded",
//    "routing": {
//    "endpoints": {
//        "eventHubs": [],
//        "serviceBusQueues": [],
//        "serviceBusTopics": [],
//        "storageContainers": []
//    },
//    "fallbackRoute": {
//        "condition": "true",
//        "endpointNames": [
//        "events"
//        ],
//        "isEnabled": true,
//        "name": "$fallback"
//    },
//    "routes": []
//    },
//    "state": "Active",
//    "storageEndpoints": {}
//},
//"resourceGroup": "IoTEdgeResources",
//"resourcegroup": "IoTEdgeResources",
//"sku": {
//    "capacity": 1,
//    "name": "F1",
//    "tier": "Free"
//},
//"subscriptionid": "6c41da6c-2ea2-4390-bb4f-a9c5c0573907",
//"tags": {},
//"type": "Microsoft.Devices/IotHubs"
//}
//]
}
