using System.Collections.Generic;
using UserRegister.Model;

namespace UserRegister.Services
{
    public interface IUserControllerService
    {
        //Returns updated all user list after new user registration.
        List<User> AddUser(string id, string password, string email, string tele);

        //Gets a single user id and password and returns whole info of current user.
        User Get(string id, string password);

        //Takes updated user as json and updates all user list and returns.
        List<User> UpdateInfo(User currUser);

        //Returns updated all user list after current user deletes.
        List<User> DeleteUser(string id);

    }
}
