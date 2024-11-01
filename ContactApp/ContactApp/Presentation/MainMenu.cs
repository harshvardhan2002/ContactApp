using ContactApp.Controllers;
using ContactApp.Models;
using ContactApp.Presentation;

namespace ContactApp.Presentation
{
    public static class MainMenu
    {
        private static AdminManager adminManager = AdminManager.Instance;
        private static StaffManager staffManager = new StaffManager();

        public static void ShowMainMenu()
        {
            if (!adminManager.GetActiveUsers().Any())
            {
                Console.WriteLine("Create an admin account to proceed.");
                AdminMenu.CreateAdminUser();
            }

            Console.WriteLine("Enter UserId:");
            int userId = Convert.ToInt32(Console.ReadLine());

            User user = adminManager.FindUser(userId);

            if (user != null && user.IsAdmin)
            {
                AdminMenu.ShowAdminMenu(user);
            }
            else if (user != null)
            {
                StaffMenu.ShowStaffMenu(user);
            }
            else
            {
                Console.WriteLine("User not found!!");
                ShowMainMenu();
            }
        }
    }
}