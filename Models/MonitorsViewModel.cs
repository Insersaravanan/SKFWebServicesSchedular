using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Models
{

    public class MonitorsViewModel
    {
        public int id { get; set; }
        public string monitorTypeName { get; set; }
        public string deviceName { get; set; }
        public string label { get; set; }
        public string machineName { get; set; }
        public bool isActive { get; set; }
        public machinesViewModel machines { get; set; }
        public devicesViewModel devices { get; set; }
        public monitorTypesViewModel monitorTypes { get; set; }
        public orientationViewModel orientation { get; set; }
       // public List<machineGroupsViewModel> machineGroup { get; set; }
       // public List<PlantsViewModel> plants { get; set; }
    }


    public class machinesViewModel
    {
        public int id { get; set; }
        public string label { get; set; }
        public machineGroupsViewModel machineGroups { get; set; }
    }

    public class devicesViewModel
    {
        public string deviceIdentifier { get; set; }
        public bool isActive { get; set; }
    }

    public class monitorTypesViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class orientationViewModel
    {
        public string code { get; set; }
        public string displayLabel { get; set; }
        public string labelX { get; set; }
        public string labelY { get; set; }
        public string labelZ { get; set; }
    }

    public class machineGroupsViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public PlantsViewModel plants { get; set; }
    }
}
