using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Models
{
    public class EquipmentViewModel
    {
        public int SEEquipmentHistoryId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string macId { get; set; }
        public int monitorId { get; set; }
        public string state { get; set; }
        public string timeDiff { get; set; }
        public string clientSiteId { get; set; }
    }
}
