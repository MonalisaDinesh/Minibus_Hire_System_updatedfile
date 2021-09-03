using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class ReservationObject
    {
        public Guid Reservation_ID { get; set; }
        public string Reservation_Date { get; set; }
        public string Reservation_Status { get; set; }
    }
}
