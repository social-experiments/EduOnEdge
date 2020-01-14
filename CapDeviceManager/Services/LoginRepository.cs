using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using CapDeviceManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CapDeviceManager.Services
{
    public class LoginRepository : ILoginRepository
    {
        public LoginModel GetLoginModel()
        {
            //Login with Az Login
            AzHelper.AzLoginWithDeviceCode();

            //Wait for 10 Seconds
            int countDownTimer = 10;
            string deviceCode = String.Empty;
            string deviceCodeToken = String.Empty;
            while (countDownTimer != 0)
            {
                deviceCode = AzHelper.azError.ToString();
                if (deviceCode.Length != 0) break;
                Thread.Sleep(1000 * 1);
                countDownTimer--;
            }

            deviceCode = AzHelper.azError.ToString();
            string[] dcsTokens = deviceCode.Split(' ');
            if (dcsTokens != null && dcsTokens.Length > 4)
            {
                deviceCodeToken = dcsTokens[dcsTokens.Length - 3];
            }

            LoginModel model = new LoginModel(deviceCodeToken);
            return model;
        }
    }
}
