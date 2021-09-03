using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Interfaces
{
    public interface ILoginService
    {
        bool UpdateLogin(LoginObject login);
        LoginObject GetLoginByID(Guid Login);
        LoginObject GetLoginByUserName(string userName);
    }
}
