using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibus_Hire_System.web.Models.Admin
{
    public class PasswordGeneratorViewModel
    {
        public string Password { get; set; } = "";

        public string Salt { get; set; } = "";

        public string HashPassword { get; set; } = "";


    }
}
