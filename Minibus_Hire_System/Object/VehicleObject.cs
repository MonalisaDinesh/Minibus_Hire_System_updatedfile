using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class VehicleObject
    {
        public Guid Vehicle_ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Mileage { get; set; }
        public string Name_plate { get; set; }
        public string Vehicle_Type { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
    }
}


