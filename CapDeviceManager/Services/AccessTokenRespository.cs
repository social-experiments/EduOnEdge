﻿using CapDeviceManager.Interfaces;
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
            AzHelper.AzAccountGetAccessToken();

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");

            if (String.IsNullOrWhiteSpace(output))
                return null;

            try
            {
                AccessTokenModel account = JsonConvert.DeserializeObject<AccessTokenModel>(output);
                return account;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
