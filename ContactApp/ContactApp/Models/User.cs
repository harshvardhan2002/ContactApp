using System.Collections.Generic;

namespace ContactApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public List<Contact> Contacts { get; set; }

        public User(int userId, string fName, string lName, bool isAdmin)
        {
            UserId = userId;
            F_Name = fName;
            L_Name = lName;
            IsAdmin = isAdmin;
            IsActive = true; 
            Contacts = new List<Contact>();
        }

        public override string ToString()
        {
            return $"User ID: {UserId}\n" +
                $"First Name: {F_Name}\n" +
                $"Last Name: {L_Name}\n" +
                $"Admin: {IsAdmin}\n" +
                $"Active: {IsActive}\n";
        }
    }
}
