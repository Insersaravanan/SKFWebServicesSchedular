using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Models
{
    public class EventsViewModel
    {
        public int id { get; set; }
        public int monitorId { get; set; }
        public string time { get; set; }
        public string level { get; set; }
        public string featureName { get; set; }
        public string value { get; set; }
        public string threshold { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string featureCode { get; set; }
        public string warningLimit { get; set; }
        public string cautionLimit { get; set; }
        public string count { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime createdOn { get; set; }
    }
}
