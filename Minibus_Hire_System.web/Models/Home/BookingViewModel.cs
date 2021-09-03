using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Models.Home
{
    public class BookingViewModel
    {
        public Guid Booking_ID { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.Text)]
        public string Booking_Type { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.DateTime)]
        public DateTime Booking_Date { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.Text)]
        public string Booking_Description { get; set; }
        

        public string PaymentType { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.Text)]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.Text)]
        public string SortCode { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.Text)]
        public string CardSecurityNumber { get; set; }
        [Required(ErrorMessage = "Booking Type is Required")]
        [DataType(DataType.Text)]
        public string UserLicenseNumber { get; set; }


        public VehicleObject Vehicle { get; set; }
    }
}
