namespace Hahn_Softwareentwicklung.Models
{
    public class BuyerModel
    {
        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Budget { get; set; }
        public List<string> Interests { get; set; }

        public BuyerModel(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, float budget, List<string> interests)
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
