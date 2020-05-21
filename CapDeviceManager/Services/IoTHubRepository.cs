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
    public class IoTHubRepository : IIoTHubRepository
    {
        public IList<IoTHubModel> GetIoTHubModels()
        {
            AzHelper.AzListIoTHub();

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");

            if (String.IsNullOrWhiteSpace(output))
                return null;

            try
            {
                IList<IoTHubModel> ioTHubModels = JsonConvert.DeserializeObject<IList<IoTHubModel>>(output);
                return ioTHubModels;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

    }
}
