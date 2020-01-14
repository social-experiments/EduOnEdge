using CapDeviceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Interfaces
{
    public interface ILoginRepository
    {
        LoginModel GetLoginModel();
    }
}
