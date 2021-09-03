using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IDatabaseService databaseService;
        public ReservationService(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;

        }

        public bool AddReservation(ReservationObject reservation)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Reservation_ID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@Reservation_ID", Value = reservation.Reservation_Date },

             };
            return databaseService.ExecuteStoredProc("AddNewReservation", parameters);
        }

        public ReservationObject GetReservationByID(Guid ReservationID)
        {
            return new ReservationObject();
        }
    }
}
