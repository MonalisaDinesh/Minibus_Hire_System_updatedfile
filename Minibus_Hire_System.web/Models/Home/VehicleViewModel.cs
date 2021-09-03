using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Models.Home
{
    public class VehicleViewModel
    {
        public Guid Vehicle_ID { get; set; }
        public string Make { get; set; }
        public string Vehicle_Model { get; set; }
        public string Mileage { get; set; }
        public string Name_plate { get; set; }
        public string Vehicle_Type { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
    }
}
