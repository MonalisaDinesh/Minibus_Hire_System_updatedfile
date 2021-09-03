using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Interfaces
{
    public interface IBookingService
    {
        bool AddBooking(BookingObject booking);
        BookingObject GetBookingByID(Guid bookingID);
    }
}
