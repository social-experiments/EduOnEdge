﻿using CapDeviceManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class LoginModel
    {
        public string URL { get; set; }

        public string DeviceCode { get; set; }

        public LoginModel(string deviceCode)
        {
            URL = "https://microsoft.com/devicelogin";
            DeviceCode = deviceCode;
        }
    }
}
