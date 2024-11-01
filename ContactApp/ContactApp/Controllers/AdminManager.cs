using System.Collections.Generic;
using System.Linq;
using ContactApp.Models;

namespace ContactApp.Controllers
{
    public class AdminManager
    {
        private static AdminManager _instance;
        private List<User> _users;

        private AdminManager()
        {
            _users = new List<User>();
        }

        public static AdminManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AdminManager();
                }
                return _instance;
            }
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public List<User> GetActiveUsers()
        {
            return _users.Where(u => u.IsActive).ToList();
        }

        public User FindUser(int userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId && u.IsActive);
        }


        public void ModifyUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.F_Name = user.F_Name;
                existingUser.L_Name = user.L_Name;
                existingUser.IsAdmin = user.IsAdmin;
            }
        }

        public void DeleteUser(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
                user.IsActive = false;
        }
    }
}
