using System;
using System.Collections.Generic;
using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using Newtonsoft.Json;
using CapDeviceManager.Utils;

namespace CapDeviceManager.Services
{
    public class IoTEdgeRepository : IIoTEdgeRepository
    {
        public IList<IoTEdgeModel> GetIoTEdgeModels(string iotHubName)
        {
            AzHelper.AzGetDevices(iotHubName);

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");
            if (String.IsNullOrWhiteSpace(output))
                return null;

            try
            {
                IList<IoTEdgeModel> ioTEdgeModels = JsonConvert.DeserializeObject<IList<IoTEdgeModel>>(output);
                
                return ioTEdgeModels;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

    }
}
