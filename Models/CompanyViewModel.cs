using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Models
{
    public class CompanyViewModel
    {
        public int? id { get; set; }
        public int? languageId { get; set; }
        public int? clientStatus { get; set; }
        public int? userId { get; set; }
        public string AppSource { get; set; }
        public string clientId { get; set; }
        public string nodeType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
