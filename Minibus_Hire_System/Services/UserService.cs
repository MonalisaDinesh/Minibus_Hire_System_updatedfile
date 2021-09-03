using Microsoft.Extensions.Options;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabaseService databaseService;
        private readonly IEncryptPasswordService encryptPasswordService;
        /// <summary>
        /// Constructor
        /// </summary>
        public UserService(IDatabaseService _databaseService, IEncryptPasswordService _encryptPasswordService)
        {
            databaseService = _databaseService;
            encryptPasswordService = _encryptPasswordService;
        }

        public bool AddUser(NewUserObject user)
        {
            var password = encryptPasswordService.EncryptPassword(user.Password);

            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@User_ID", Value = Guid.NewGuid() },
                new SqlParameter { ParameterName = "@First_Name", Value = user.FirstName },
                new SqlParameter { ParameterName = "@Last_Name", Value = user.LastName },
                new SqlParameter { ParameterName = "@Address1", Value = user.Address1 },
                new SqlParameter { ParameterName = "@Address2", Value = user.Address2 },
                new SqlParameter { ParameterName = "@Address3", Value = user.Address3 },
                new SqlParameter { ParameterName = "@PostCode", Value = user.PostCode },
                new SqlParameter { ParameterName = "@City", Value = user.City },
                new SqlParameter { ParameterName = "@County", Value = user.County },
                new SqlParameter { ParameterName = "@Country", Value = user.Country },
                new SqlParameter { ParameterName = "@Email_Address", Value = user.Email },
                new SqlParameter { ParameterName = "@Mobile_NO", Value = user.PhoneNumber },
                new SqlParameter { ParameterName = "@Username", Value = user.Username },
                new SqlParameter { ParameterName = "@Password", Value = password.HashPassword },
                new SqlParameter { ParameterName = "@Salt", Value = password.Salt },
                new SqlParameter { ParameterName = "@Role", Value = user.Role }
            };

            return databaseService.ExecuteStoredProc("CreateNewUser", parameters);
        }

        public UserObject GetUserByID(Guid userID)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@User_ID", Value = userID },
            };
            IList<UserObject> _result = new List<UserObject>();
            var response = databaseService.GetList("tblUser_GetByID", parameters);
            foreach (DataRow _row in response.Rows)
            {
                _result.Add(new UserObject
                {
                    UserId = Guid.Parse(_row["User_ID"].ToString()),
                    FirstName = _row["First_Name"].ToString(),
                    LastName = _row["Last_Name"].ToString(),
                    Address1 = _row["Address1"].ToString(),
                    Address2 = _row["Address2"].ToString(),
                    Address3 = _row["Address3"].ToString(),
                    PostCode = _row["PostCode"].ToString(),
                    City = _row["City"].ToString(),
                    County = _row["County"].ToString(),
                    Country = _row["Country"].ToString(),
                    Email = _row["Email_Address"].ToString(),
                    PhoneNumber = _row["Mobile_NO"].ToString()
                });
            }
            return _result.FirstOrDefault();
        }

        public IEnumerable<UserObject> GetCustomer()
        {
            IList<UserObject> _result = new List<UserObject>();
            var response = databaseService.GetList("GetCustomerList");
            foreach (DataRow _row in response.Rows)
            {
                _result.Add(new UserObject
                {
                    UserId = Guid.Parse(_row["User_ID"].ToString()),
                    FirstName = _row["First_Name"].ToString(),
                    LastName = _row["Last_Name"].ToString(),
                    Address1 = _row["Address1"].ToString(),
                    Address2 = _row["Address2"].ToString(),
                    Address3 = _row["Address3"].ToString(),
                    PostCode = _row["PostCode"].ToString(),
                    City = _row["City"].ToString(),
                    County = _row["County"].ToString(),
                    Country = _row["Country"].ToString(),
                    Email = _row["Email_Address"].ToString(),
                    PhoneNumber = _row["Mobile_NO"].ToString()
                });
            }
            return _result.AsEnumerable();
        }

    }
}
