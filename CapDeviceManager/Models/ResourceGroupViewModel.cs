using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class ResourceGroupViewModel
    {
        public string ResourceGroupName { get; set; }
        public IList<SelectListItem> ResourceGroups { get; set; }
    }
}
