using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDatabaseService databaseService;
        public BookingService(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }

        public bool AddBooking(BookingObject booking)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Booking_ID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@Booking_Type", Value = booking.Booking_Type },
                new SqlParameter { ParameterName = "@Vehicle_ID", Value = booking.Vehicle_ID },
                new SqlParameter { ParameterName = "@Booking_Date", Value = booking.Booking_Date },
                new SqlParameter { ParameterName = "@Booking_Description", Value = booking.Booking_Description },
                new SqlParameter { ParameterName = "@PaymentType", Value = booking.PaymentType },
                new SqlParameter { ParameterName = "@CardNumber", Value = booking.CardNumber },
                new SqlParameter { ParameterName = "@SortCode", Value = booking.SortCode },
                new SqlParameter { ParameterName = "@CardSecurityNumber", Value = booking.CardSecurityNumber },
                new SqlParameter { ParameterName = "@User_ID", Value = booking.User_ID },
                new SqlParameter { ParameterName = "@UserLicenseNumbe", Value = booking.UserLicenseNumber },

            };
            return databaseService.ExecuteStoredProc("tblBooking_ADD", parameters);
        }
        public BookingObject GetBookingByID(Guid BookingID)
        {
            return new BookingObject();
        }
    }     
}
