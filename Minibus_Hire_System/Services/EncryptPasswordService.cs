using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Object;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Minibus_Hire_System.Services
{
    public class EncryptPasswordService : IEncryptPasswordService
    {
        public EncryptPasswordService() { }
        public EncryptPasswordObject EncryptPassword(string password, string salt = null)
        {
            var _salt = string.IsNullOrWhiteSpace(salt) ? GenerateSalt(50) : salt;
            return new EncryptPasswordObject
            {
                Salt = _salt,// Encoding.ASCII.GetString(_salt),
                HashPassword = HashPassword(password, _salt)
            };
        }
        private string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {

            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(
                password, 
                saltBytes,
                10000))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(100));
            }
        }
    }
}
