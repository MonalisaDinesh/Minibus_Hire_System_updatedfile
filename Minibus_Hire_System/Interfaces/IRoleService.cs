using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Interfaces
{
    interface IRoleService
    {
        bool AddRole(RoleObject role);
        RoleObject GetRoleByID(Guid RoleID);

    }
}
