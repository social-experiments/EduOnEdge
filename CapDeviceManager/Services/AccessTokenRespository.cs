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
    public class AccessTokenRepository : IAccessTokenRepository
    {
        public AccessTokenModel GetAccessTokenModel()
        {
            //Login with Az Login
            AzHelper.AzAccountGetAccessToken();

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");

            AccessTokenModel account = JsonConvert.DeserializeObject<AccessTokenModel>(output);
            return account;
        }
    }
}
