using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Interfaces
{
    public interface IVehicleService
    {
        bool AddVehicle(VehicleObject vehicle);
        bool UpdateVehicle(VehicleObject vehicle);
        VehicleObject GetVehicleByID(Guid VehicleID);
        IEnumerable<VehicleObject> GetListOfVehicle();
    }
}
