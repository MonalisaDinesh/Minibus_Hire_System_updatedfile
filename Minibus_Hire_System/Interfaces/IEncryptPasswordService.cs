using Minibus_Hire_System.Object;

namespace Minibus_Hire_System.Interfaces
{
    public interface IEncryptPasswordService
    {
        EncryptPasswordObject EncryptPassword(string password, string salt = null);
    }
}
