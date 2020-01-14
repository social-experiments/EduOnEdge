using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class UserModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
    public class AccountModel
    {
        [JsonProperty(PropertyName = "user")]
        public UserModel User { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}

/*
c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2>az account show
{
  "environmentName": "AzureCloud",
  "id": "6c41da6c-2ea2-4390-bb4f-a9c5c0573907",
  "isDefault": true,
  "name": "Azure Free Trial",
  "state": "Enabled",
  "tenantId": "cd718841-d840-4586-8601-bd1637cbc936",
  "user": {
    "name": "ssomasundaram@live.com",
    "type": "user"
  }
}

c:\Program Files (x86)\Microsoft SDKs\Azure\CLI2>az account show
Please run 'az login' to setup account.
 */
