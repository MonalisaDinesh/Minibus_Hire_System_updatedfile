using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class LoginObject
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role_ID { get; set; }
        public string Role { get; set; }
        public string LastLoginDate { get; set; }
        public string Created_Date { get; set; }
    }
}
