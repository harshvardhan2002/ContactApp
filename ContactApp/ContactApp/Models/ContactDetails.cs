namespace ContactApp.Models
{
    public class ContactDetails
    {
        public int ContactDetailsId { get; set; }
        public string Type { get; set; } 
        public string Number { get; set; }
        public string Email { get; set; }

        public ContactDetails(int contactDetailsId, string type, string number, string email)
        {
            ContactDetailsId = contactDetailsId;
            Type = type;
            Number = number;
            Email = email;
        }

        public override string ToString()
        {
            return $"Details ID: {ContactDetailsId}\n" +
                $"Type: {Type}\n" +
                $"Number: {Number}\n" +
                $"Email: {Email}\n";
        }
    }
}
