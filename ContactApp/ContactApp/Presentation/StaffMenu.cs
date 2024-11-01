using System;
using ContactApp.Models;
using ContactApp.Controllers;

namespace ContactApp.Presentation
{
    internal static class StaffMenu
    {
        private static StaffManager staffManager = new StaffManager();

        public static void ShowStaffMenu(User user)
        {
            while (true)
            {
                DisplayStaffMenu();

                int choice = Convert.ToInt32(Console.ReadLine());

                StaffMenuChoice(choice, user);
            }
        }

        private static void DisplayStaffMenu()
        {
            Console.WriteLine($"Staff Menu:\n" +
                $"1. Write Contacts\n" +
                $"2. Write Contact Details\n" +
                $"3. Go Back to Main Menu\n" +
                $"4. Logout");
        }

        private static void StaffMenuChoice(int choice, User user)
        {
            switch (choice)
            {
                case 1:
                    ManageContacts(user);
                    break;
                case 2:
                    ManageContactDetails(user);
                    break;
                case 3:
                    MainMenu.ShowMainMenu();
                    return;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
        }

        private static void ManageContacts(User user)
        {
            while (true)
            {
                DisplayContactManagementMenu();

                int choice = Convert.ToInt32(Console.ReadLine());
                if (!StaffsContactMenuChoice(choice, user))
                    break;
            }
        }

        private static void DisplayContactManagementMenu()
        {
            Console.WriteLine($"Contact Management Menu:\n" +
                $"1. Add New Contact\n" +
                $"2. Modify Contact\n" +
                $"3. Delete Contact\n" +
                $"4. Display All Contacts\n" +
                $"5. Find Contact\n" +
                $"6. Back to Staff Menu");
        }

        private static bool StaffsContactMenuChoice(int choice, User user)
        {
            switch (choice)
            {
                case 1:
                    AddContact(user);
                    break;
                case 2:
                    ModifyContact(user);
                    break;
                case 3:
                    DeleteContact(user);
                    break;
                case 4:
                    DisplayAllContacts(user);
                    break;
                case 5:
                    FindContact(user);
                    break;
                case 6:
                    return false;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
            return true;
        }

        private static void AddContact(User user)
        {
            Console.WriteLine("Enter Contact ID:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lname = Console.ReadLine();

            Contact newContact = new Contact(contactId, fname, lname);
            staffManager.AddContact(user, newContact);
            Console.WriteLine("Contact added successfully.");
        }

        private static void ModifyContact(User user)
        {
            Console.WriteLine("Enter Contact ID to modify:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new First Name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter new Last Name:");
            string lname = Console.ReadLine();

            Contact modifiedContact = new Contact(contactId, fname, lname);
            staffManager.ModifyContact(user, modifiedContact);
            Console.WriteLine("Contact modified successfully.");
        }

        private static void DeleteContact(User user)
        {
            Console.WriteLine("Enter Contact ID to delete:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            staffManager.DeleteContact(user, contactId);
            Console.WriteLine("Contact deleted.");
        }

        private static void DisplayAllContacts(User user)
        {
            var activeContacts = staffManager.GetActiveContacts(user);
            if (activeContacts.Any())
            {
                foreach (var contact in activeContacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("No active contacts found.");
            }
        }

        private static void FindContact(User user)
        {
            Console.WriteLine("Enter Contact ID to find:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Contact foundContact = staffManager.FindContact(user, contactId);
            if (foundContact != null)
            {
                Console.WriteLine(foundContact);
            }
            else
            {
                Console.WriteLine("Contact not found or inactive.");
            }
        }

        private static void ManageContactDetails(User user)
        {
            while (true)
            {
                DisplayContactDetailsManagementMenu();

                int choice = Convert.ToInt32(Console.ReadLine());
                if (!StaffsContactDetailsMenuChoice(choice, user))
                    break;
            }
        }

        private static void DisplayContactDetailsManagementMenu()
        {
            Console.WriteLine("Contact Details Management Menu:\n" +
                "1. Add New Contact Details\n" +
                "2. Modify Contact Details\n" +
                "3. Delete Contact Details\n" +
                "4. Display all Contact Details\n" +
                "5. Find Contact Details\n" +
                "6. back to staff menu");
        }

        private static bool StaffsContactDetailsMenuChoice(int choice, User user)
        {
            switch (choice)
            {
                case 1:
                    AddContactDetails(user);
                    break;
                case 2:
                    ModifyContactDetails(user);
                    break;
                case 3:
                    DeleteContactDetails(user);
                    break;
                case 4:
                    DisplayAllContactDetails(user);
                    break;
                case 5:
                    FindContactDetails(user);
                    break;
                case 6:
                    return false;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
            return true;
        }

        private static void AddContactDetails(User user)
        {
            Console.WriteLine("Enter Contact ID for details:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Details ID:");
            int detailsId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Type (Business/Residential):");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Number:");
            string number = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            ContactDetails newDetails = new ContactDetails(detailsId, type, number, email);
            staffManager.AddContactDetails(user, contactId, newDetails);
            Console.WriteLine("Contact details added successfully.");
        }

        private static void ModifyContactDetails(User user)
        {
            Console.WriteLine("Enter Contact ID for details:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Details ID to modify:");
            int detailsId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Type:");
            string type = Console.ReadLine();
            Console.WriteLine("Enter new Number:");
            string number = Console.ReadLine();
            Console.WriteLine("Enter new Email:");
            string email = Console.ReadLine();

            ContactDetails modifiedDetails = new ContactDetails(detailsId, type, number, email);
            staffManager.ModifyContactDetails(user, contactId, modifiedDetails);
            Console.WriteLine("Contact details modified successfully.");
        }

        private static void DeleteContactDetails(User user)
        {
            Console.WriteLine("Enter Contact ID for details:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Details ID to delete:");
            int detailsId = Convert.ToInt32(Console.ReadLine());
            staffManager.DeleteContactDetails(user, contactId, detailsId);
            Console.WriteLine("Contact details deleted.");
        }

        private static void DisplayAllContactDetails(User user)
        {
            Console.WriteLine("Enter Contact ID to display details:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var contactDetails = user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId)?.ContactDetails;
            if (contactDetails != null && contactDetails.Any())
            {
                foreach (var detail in contactDetails)
                {
                    Console.WriteLine(detail);
                }
            }
            else
            {
                Console.WriteLine("No details found for this contact.");
            }
        }

        private static void FindContactDetails(User user)
        {
            Console.WriteLine("Enter Contact ID for details:");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Details ID to find:");
            int detailsId = Convert.ToInt32(Console.ReadLine());

            var contact = user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId);
            if (contact != null)
            {
                var foundDetail = contact.ContactDetails.FirstOrDefault(d => d.ContactDetailsId == detailsId);
                if (foundDetail != null)
                {
                    Console.WriteLine(foundDetail);
                    return;
                }
                Console.WriteLine("Contact detail not found.");
                return;
            }
            Console.WriteLine("Contact not found.");
        }
    }
}
