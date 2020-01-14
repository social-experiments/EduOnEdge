using CapDeviceManager.Interfaces;
using CapDeviceManager.Models;
using CapDeviceManager.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Services
{
    public class AccountRepository : IAccountRepository
    {
        public AccountModel GetAccountModel()
        {
            AzHelper.AzAccountDetails();

            string output = AzHelper.azOutput.ToString();
            output = output.Replace("\r\n", "");

            if (String.IsNullOrWhiteSpace(output))
                return null;

            try
            {
                AccountModel account = JsonConvert.DeserializeObject<AccountModel>(output);
                return account;
            }
            catch(Exception exc)
            {
                return null;
            }
        }
    }
}
