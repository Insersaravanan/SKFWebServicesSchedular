using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Models
{
    public class LoginViewModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string language { get; set; }
        public string accessToken { get; set; }
        public bool loggedIn { get; set; }
        public bool admin { get; set; }
        public List<scopeSelectorViewModel> scopeSelector { get; set; }
        public List<subOrganizationsViewModel> subOrganizations { get; set; }
        public List<PlantsViewModel> plants { get; set; }
    }

    public class scopeSelectorViewModel
    {
        public List<subOrganizationsViewModel> subOrganizations { get; set; }
    }

    public class subOrganizationsViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string organizationType { get; set; }
        public string defaultLanguage { get; set; }
        public bool root { get; set; }
        public List<PlantsViewModel> plants { get; set; }
    }

}
