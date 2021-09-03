using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDatabaseService databaseService;
        public LoginService(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }

        public bool UpdateLogin(LoginObject login)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@UserID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@Username", Value = login.Username },
                new SqlParameter { ParameterName = "@Password", Value = login.Password },
                new SqlParameter { ParameterName = "@Salt", Value = login.Salt },
                new SqlParameter { ParameterName = "@Role", Value = login.Role},
                new SqlParameter { ParameterName = "@LastLoginDate", Value = login.LastLoginDate }
            };
            return databaseService.ExecuteStoredProc("tblLogin_UPDATE", parameters);
        }

        public LoginObject GetLoginByID(Guid Login)
        {
            return new LoginObject();
        }

        public LoginObject GetLoginByUserName(string userName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>{
                new SqlParameter { ParameterName = "@Username", Value = userName }
            };
            var userLogin = databaseService.GetList("tblLogin_GetByUserName", parameters);
            if (userLogin == null || userLogin.Rows.Count <= 0)
                return null;
            else
                return new LoginObject
                {
                    UserID = Guid.Parse(userLogin.Rows[0]["User_ID"].ToString()),
                    Username = userLogin.Rows[0]["Username"].ToString(),
                    Password = userLogin.Rows[0]["Password"].ToString(),
                    Salt = userLogin.Rows[0]["Salt"].ToString(),
                    Role = userLogin.Rows[0]["Role"].ToString()
                };
        }
    }
    
    
}
