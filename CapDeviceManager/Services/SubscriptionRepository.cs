using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using CapDeviceManager.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CapDeviceManager.Services
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public IList<SubscriptionModel> GetSubscriptionModels()
        {
            //Login with Az Login
            AzHelper.AzGetSubscription();

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");
            
            IList<SubscriptionModel> subscriptions = JsonConvert.DeserializeObject<IList<SubscriptionModel>>(output);
            return subscriptions;
        }
    }
}
