using System.Collections.Generic;
using System.Linq;
using ContactApp.Models;

namespace ContactApp.Controllers
{
    public class StaffManager
    {
        public void AddContact(User user, Contact contact)
        {
            if (user.IsActive)
                user.Contacts.Add(contact);
            
        }

        public void ModifyContact(User user, Contact contact)
        {
            if (!user.IsActive) 
                return;

            var existingContact = user.Contacts.FirstOrDefault(c => c.Contact_Id == contact.Contact_Id);
            if (existingContact != null)
            {
                existingContact.FName = contact.FName;
                existingContact.LName = contact.LName;
            }
        }

        public void DeleteContact(User user, int contactId)
        {
            if (!user.IsActive) 
                return;

            var contact = user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId);
            if (contact != null)
                contact.IsActive = false;
        }

        public List<Contact> GetActiveContacts(User user)
        {
            if (user.IsActive)
            {
                return user.Contacts.Where(c => c.IsActive).ToList();
            }
            return new List<Contact>();
        }

        public Contact FindContact(User user, int contactId)
        {
            if (user.IsActive)
            {
                return user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId && c.IsActive);
            }
            return null;
        }

        public void AddContactDetails(User user, int contactId, ContactDetails details)
        {
            if (!user.IsActive) return;

            var contact = user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId);
            if (contact != null)
                contact.ContactDetails.Add(details);
        }

        public void ModifyContactDetails(User user, int contactId, ContactDetails details)
        {
            if (!user.IsActive) 
                return;

            var contact = user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId);
            if (contact != null)
            {
                var existingDetail = contact.ContactDetails.FirstOrDefault(d => d.ContactDetailsId == details.ContactDetailsId);
                if (existingDetail != null)
                {
                    existingDetail.Type = details.Type;
                    existingDetail.Number = details.Number;
                    existingDetail.Email = details.Email;
                }
            }
        }

        public void DeleteContactDetails(User user, int contactId, int detailId)
        {
            if (!user.IsActive) 
                return;

            var contact = user.Contacts.FirstOrDefault(c => c.Contact_Id == contactId);
            if (contact != null)
            {
                var detail = contact.ContactDetails.FirstOrDefault(d => d.ContactDetailsId == detailId);
                if (detail != null)
                    contact.ContactDetails.Remove(detail);
            }
        }
    }
}
