using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Minibus_Hire_System.Object
{
    public class DatabaseConnectionStringObject
    {
        public SqlConnectionStringBuilder ConnectionStringBuilder { get; set; }
    }
}
