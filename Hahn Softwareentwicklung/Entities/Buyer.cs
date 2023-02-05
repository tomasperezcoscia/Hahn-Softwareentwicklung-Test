namespace Hahn_Softwareentwicklung.Entities
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public float Budget { get; set; }
        public List<string> Interests { get;set; }

        public Buyer(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, float budget, List<string> interests)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Budget = budget;
            Interests = interests;
        }
    }
}
