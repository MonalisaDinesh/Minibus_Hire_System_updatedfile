using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class EncryptPasswordObject
    {
        public string Salt { get; set; }
        public string HashPassword { get; set; }
    }
}
