using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class AuthoriseObject
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

    }
}
