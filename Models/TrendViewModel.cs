using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Models
{
    public class TrendViewModel
    {
        public string time { get; set; }
        public int monitorId { get; set; }
        public string jsonavg { get; set; }
        public string jsonmin { get; set; }
    }

    public class listViewModel
    {
        public List<TrendViewModel> fingerPrintList { get; set; }
        public List<TrendViewModel> basicFeatures { get; set; }
    }
}
