using System;
using ContactApp.Models;
using ContactApp.Controllers;

namespace ContactApp.Presentation
{
    public static class AdminMenu
    {
        private static AdminManager adminManager = AdminManager.Instance;

        public static void ShowAdminMenu(User user)
        {
            while (true)
            {
                DisplayAdminMenu();

                int choice = Convert.ToInt32(Console.ReadLine());
                if (!AdminUserMenuChoice(choice))
                    break;
            }
        }

        private static void DisplayAdminMenu()
        {
            Console.WriteLine($"Admin menu:\n" +
                $"1. Add new user\n" +
                $"2. Modify existing user\n" +
                $"3. Delete user\n" +
                $"4. Display all users\n" +
                $"5. Find user\n" +
                $"6. Go to Main Menu\n" +
                $"7. Logout");
        }

        private static bool AdminUserMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewUser();
                    break;
                case 2:
                    ModifyUser();
                    break;
                case 3:
                    DeleteUser();
                    break;
                case 4:
                    DisplayAllUsers();
                    break;
                case 5:
                    FindUser();
                    break;
                case 6:
                    MainMenu.ShowMainMenu();
                    return false;
                case 7:
                    return false;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
            return true;
        }

        public static void CreateAdminUser()
        {
            Console.WriteLine("Create Admin Account:");
            Console.WriteLine("Enter User ID:");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lName = Console.ReadLine();

            User newUser = new User(userId, fName, lName, isAdmin: true);
            adminManager.AddUser(newUser);
            Console.WriteLine("Admin user created successfully.");
        }

        private static void AddNewUser()
        {
            Console.WriteLine("Enter User ID:");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lName = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false):");
            bool isAdmin = Convert.ToBoolean(Console.ReadLine());

            User newUser = new User(userId, fName, lName, isAdmin);
            adminManager.AddUser(newUser);
            Console.WriteLine("User added successfully.");
        }

        private static void ModifyUser()
        {
            Console.WriteLine("Enter User ID to modify:");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new First Name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter new Last Name:");
            string lName = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false):");
            bool isAdmin = Convert.ToBoolean(Console.ReadLine());

            User modifiedUser = new User(userId, fName, lName, isAdmin);
            adminManager.ModifyUser(modifiedUser);
            Console.WriteLine("User modified successfully.");
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter User ID to delete:");
            int userId = Convert.ToInt32(Console.ReadLine());
            adminManager.DeleteUser(userId);
            Console.WriteLine("User deleted");
        }

        private static void DisplayAllUsers()
        {
            var activeUsers = adminManager.GetActiveUsers();
            foreach (var user in activeUsers)
            {
                Console.WriteLine(user);
            }
        }

        private static void FindUser()
        {
            Console.WriteLine("Enter User ID to find:");
            int userId = Convert.ToInt32(Console.ReadLine());
            User foundUser = adminManager.FindUser(userId);
            if (foundUser != null)
            {
                Console.WriteLine(foundUser);
                return;
            }
            Console.WriteLine("User not found!");
        }
    }
}
