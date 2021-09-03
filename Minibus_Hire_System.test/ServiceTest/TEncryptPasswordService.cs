using Minibus_Hire_System.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minibus_Hire_System.test.ServiceTest
{
    public class TEncryptPasswordService
    {
        private EncryptPasswordService passwordService;

        [SetUp]
        public void Setup()
        {
            passwordService = new EncryptPasswordService();
        }

        [Test]

        public void GenerateNewPasswordEncryption()
        {
            string password = "Password";
            var hashPassword = passwordService.EncryptPassword(password);
            Assert.That(string.IsNullOrWhiteSpace(hashPassword.Salt), Is.False);
            Assert.That(string.IsNullOrWhiteSpace(hashPassword.HashPassword), Is.False);
        }

        [Test]
        public void GeneratePasswordWithSalt()
        {
            string password = "Password";
            string salt = "4jz0p9sBIyk+DhzyNRec5r9cXnUYqfe+MT0j57sl2n7VeMjsU6uBOjT4xGDiRxs3dkg=";
            string _hashPassword = "rRZCOqS7Mj78MvqQTmvTRZ+tHWO0n0lS4nQBP4o1RWD/0eor1fDzJNRtEfXLkxO8t3pf6DWu417FnphplcW4BZ00aHCCHW9YGX5uf7UxhobfStNOP6Tk7Z2g+Kk4kBTFv9Sgiw==";
            var hashPassword = passwordService.EncryptPassword(password, salt);
            Assert.That(hashPassword.HashPassword, Is.EqualTo(_hashPassword));
        }

        [Test]
        public void GeneratePasswordWithSaltAuth()
        {
            string password = "Password";
            var passwordWithoutSalt = passwordService.EncryptPassword(password);
            var passwordWithSalt = passwordService.EncryptPassword(password, passwordWithoutSalt.Salt);
            Assert.That(passwordWithoutSalt.HashPassword, Is.EqualTo(passwordWithSalt.HashPassword));
        }
    }
}
