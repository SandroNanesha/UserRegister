 using System;
using System.Collections.Generic;
using System.Linq;
using UserRegister.Model;
using UserRegister.Validators;

namespace UserRegister.Services
{
    public class UserControllerService : IUserControllerService
    {
        public List<User> AddUser(string id, string password, string email, string tele)
        {
            using (var context = new ApplicationDbContext())
            {

                User newUser = new User();
                newUser.Id = id;
                newUser.PasswordHash = password;
                newUser.Email = email;
                newUser.PhoneNumber = tele;

                UserVlidator validator = new UserVlidator();
                var valid = validator.Validate(newUser);

                if (valid.IsValid && !context.profiles.Contains(newUser))
                {
                    context.profiles.Add(newUser);
                    context.SaveChanges();

                }
                return context.profiles.ToList();
            }
        }

        public List<User> DeleteUser(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                //No validations
                User currUser = context.profiles.FirstOrDefault(u => u.Id == id);
                if(currUser != null)
                {
                    context.profiles.Remove(currUser);
                    context.SaveChanges();
                    
                }

                return context.profiles.ToList();

            }
        }

        public User Get(string id, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                List<User> allUser = context.profiles.ToList();
                UserVlidator validator = new UserVlidator();

                return allUser.FirstOrDefault(c => (c.Id == id && c.PasswordHash == password && validator.Validate(c).IsValid));
            }
        }

        public List<User> UpdateInfo(User currUser)
        {
            using (var context = new ApplicationDbContext())
            {
                UserVlidator validator = new UserVlidator();
                var valid = validator.Validate(currUser);
                if (valid.IsValid)
                {
                    context.profiles.Update(currUser);
                    context.SaveChanges();
                }

                return context.profiles.ToList();
            }
        }
    }
}
