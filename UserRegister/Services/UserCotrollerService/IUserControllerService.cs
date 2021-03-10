using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegister.Model;

namespace UserRegister.Services
{
    public interface IUserControllerService
    {
        List<User> AddUser(string id, string password, string email, string tele);

        User Get(string id, string password);

        List<User> UpdateInfo(User currUser);

        List<User> DeleteUser(User currUser);

    }
}
