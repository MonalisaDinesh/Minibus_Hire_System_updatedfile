using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ILoginService loginService;
        private readonly IEncryptPasswordService encryptPasswordService;
        private readonly IUserService userService;
        public SecurityService(ILoginService _loginService, IEncryptPasswordService _encryptPasswordService, IUserService _userService)
        {
            loginService = _loginService;
            encryptPasswordService = _encryptPasswordService;
            userService = _userService;
        }

        public AuthoriseObject Authenticate(string email, string password)
        {
            try
            {
                var login = loginService.GetLoginByUserName(email);
                if (login == null)
                    return null;
                var result = encryptPasswordService.EncryptPassword(password, login.Salt);

                if (result.HashPassword == login.Password)
                {
                    var user = userService.GetUserByID(login.UserID);
                    if(user == null)
                        return null;
                    return new AuthoriseObject
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserID = user.UserId,
                        UserName = login.Username,
                        Role = login.Role
                    };
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
