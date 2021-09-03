using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IDatabaseService databaseService;
        public VehicleService(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }

        public bool AddVehicle(VehicleObject vehicle)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter { ParameterName = "@Vehicle_ID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@Make", Value = vehicle.Make },
                new SqlParameter { ParameterName = "@Model", Value = vehicle.Model },
                new SqlParameter { ParameterName = "@Mileage", Value = vehicle.Mileage },
                new SqlParameter { ParameterName = "@Name_Plate", Value = vehicle.Name_plate },
                new SqlParameter { ParameterName = "@Vehicle_Type", Value = vehicle.Vehicle_Type },
                new SqlParameter { ParameterName = "@Description", Value = vehicle.Description },
                new SqlParameter { ParameterName = "@ImageFileName", Value = vehicle.ImageFileName }
            };
            return databaseService.ExecuteStoredProc("tblVehicle_Add", parameters);
        }

        public bool UpdateVehicle(VehicleObject vehicle)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter { ParameterName = "@Vehicle_ID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@Make", Value = vehicle.Make },
                new SqlParameter { ParameterName = "@Model", Value = vehicle.Model },
                new SqlParameter { ParameterName = "@Mileage", Value = vehicle.Mileage },
                new SqlParameter { ParameterName = "@Name_Plate", Value = vehicle.Name_plate },
                new SqlParameter { ParameterName = "@Vehicle_Type", Value = vehicle.Vehicle_Type },
                new SqlParameter { ParameterName = "@Description", Value = vehicle.Description },
                new SqlParameter { ParameterName = "@ImageFileName", Value = vehicle.ImageFileName }
            };
            return databaseService.ExecuteStoredProc("tblVehicle_UPDATE", parameters);
        }

        public VehicleObject GetVehicleByID(Guid VehicleID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter { ParameterName = "@Vehicle_ID", Value = VehicleID }
            };
            var response = databaseService.GetList("tblVechile_GetByVehicleID", parameters);
            IList<VehicleObject> _result = new List<VehicleObject>();
            foreach (DataRow _row in response.Rows)
            {
                _result.Add(new VehicleObject
                {
                    Vehicle_ID = Guid.Parse(_row["Vehicle_ID"].ToString()),
                    Make = _row["Make"].ToString(),
                    Model = _row["Model"].ToString(),
                    Mileage = _row["Mileage"].ToString(),
                    Name_plate = _row["Name_Plate"].ToString(),
                    Vehicle_Type = _row["Vehicle_TYpe"].ToString(),
                    Description = _row["Description"].ToString(),
                    ImageFileName = _row["ImageFileName"].ToString()
                });
            }
            return _result.FirstOrDefault();
        }

        public IEnumerable<VehicleObject> GetListOfVehicle()
        {
            IList<VehicleObject> _result = new List<VehicleObject>();
            var response = databaseService.GetList("tblVechile_List");
            foreach (DataRow _row in response.Rows)
            {
                _result.Add(new VehicleObject
                {
                    Vehicle_ID = Guid.Parse(_row["Vehicle_ID"].ToString()),
                    Make = _row["Make"].ToString(),
                    Model = _row["Model"].ToString(),
                    Mileage = _row["Mileage"].ToString(),
                    Name_plate = _row["Name_Plate"].ToString(),
                    Vehicle_Type = _row["Vehicle_TYpe"].ToString(),
                    Description = _row["Description"].ToString(),
                    ImageFileName = _row["ImageFileName"].ToString()
                });
            }
            return _result.AsEnumerable();
        }
    }
}
