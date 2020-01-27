using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using CapDeviceManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CapDeviceManager.Services
{
    public class LoginRepository : ILoginRepository
    {
        //To sign in, use a web browser to open the page https://microsoft.com/devicelogin and enter the code BM5M4CEHJ to authenticate.
        public LoginModel GetLoginModel()
        {
            //Login with Az Login
            AzHelper.AzLoginWithDeviceCode();

            //Wait for 20 Seconds
            int countDownTimer = 30;
            string deviceCode = String.Empty;
            string deviceCodeToken = String.Empty;
            while (countDownTimer != 0)
            {
                deviceCode = AzHelper.azError.ToString();
                if (deviceCode.Length != 0 && deviceCode.Contains("enter the code")) break;
                Thread.Sleep(1000 * 1);
                countDownTimer--;
            }

            deviceCode = AzHelper.azError.ToString();

            string urlKey = "https://microsoft.com/devicelogin";

            Match codeMatch = Regex.Match(deviceCode, @"enter the code ([A-Z0-9]+) to authenticate", RegexOptions.IgnoreCase);
            if (!codeMatch.Success) return null;
            string codeKey = codeMatch.Groups[1].Value;
            Console.WriteLine(codeKey);

            if (String.IsNullOrWhiteSpace(urlKey))
                return null;
            if (String.IsNullOrWhiteSpace(codeKey))
                return null;

            try
            {
                LoginModel model = new LoginModel(urlKey, codeKey);
                return model;
            }
            catch (Exception exc)
            {
                return null;
            }

        }
    }
}
