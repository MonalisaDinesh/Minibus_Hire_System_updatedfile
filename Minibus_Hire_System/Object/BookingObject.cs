using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
  public class BookingObject
    {
        public Guid Booking_ID { get; set; }
        public string Booking_Type { get; set; }
        public Guid Vehicle_ID { get; set; }
        public DateTime Booking_Date { get; set; }
        public string Booking_Description { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }
        public string SortCode { get; set; }
        public string CardSecurityNumber { get; set; }
        public Guid User_ID { get; set; }
        public string UserLicenseNumber { get; set; }

    }
}
