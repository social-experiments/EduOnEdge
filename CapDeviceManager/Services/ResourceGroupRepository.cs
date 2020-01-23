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
    public class ResourceGroupRepository : IResourceGroupRepository
    {
        public IList<ResourceGroupModel> GetResourceGroupModels()
        {
            AzHelper.AzListResourceGroup();

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");

            if (String.IsNullOrWhiteSpace(output))
                return null;

            try
            {
                IList<ResourceGroupModel> resourceGroups = JsonConvert.DeserializeObject<IList<ResourceGroupModel>>(output);
                return resourceGroups;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
