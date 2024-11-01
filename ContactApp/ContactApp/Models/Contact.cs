using System.Collections.Generic;

namespace ContactApp.Models
{
    public class Contact
    {
        public int Contact_Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsActive { get; set; }
        public List<ContactDetails> ContactDetails { get; set; }

        public Contact(int contactId, string fName, string lName)
        {
            Contact_Id = contactId;
            FName = fName;
            LName = lName;
            IsActive = true;
            ContactDetails = new List<ContactDetails>();
        }

        public override string ToString()
        {
            return $"Contact ID: {Contact_Id}\n" +
                $"First Name: {FName}\n" +
                $"Last Name: {LName}\n" +
                $"Active: {IsActive}\n";
        }
    }
}
