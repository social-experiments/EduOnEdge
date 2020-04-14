using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapDeviceManager.Models
{
    public class IoTEdgeViewModel
    {
        public string IoTEdgeName { get; set; }
        public IList<SelectListItem> IoTEdges { get; set; }
    }
}
