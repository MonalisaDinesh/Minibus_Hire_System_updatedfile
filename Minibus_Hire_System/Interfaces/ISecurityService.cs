using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Interfaces
{
    public interface ISecurityService
    {
        AuthoriseObject Authenticate(string email, string password);
    }
}
