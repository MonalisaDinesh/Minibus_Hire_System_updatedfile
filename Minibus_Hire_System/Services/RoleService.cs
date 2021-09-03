using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDatabaseService databaseService;
        public RoleService(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }

        public bool AddRole(RoleObject role)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Role_ID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@Role_Type", Value = role.Role_Type},
            };
            return databaseService.ExecuteStoredProc("AddNewRole", parameters);
        }

        public RoleObject GetRoleByID(Guid RoleID)
        {
            return new RoleObject();
        }
    }
}
