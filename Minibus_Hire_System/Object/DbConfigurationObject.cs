using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class DbConfigurationObject
    {
        public string DataSource { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string InitialCatalog { get; set; }
    }
}
