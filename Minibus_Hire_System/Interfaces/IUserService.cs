using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Interfaces
{
    public interface IUserService
    {
        bool AddUser(NewUserObject user);
        UserObject GetUserByID(Guid userID);
        IEnumerable<UserObject> GetCustomer();
    }
}
