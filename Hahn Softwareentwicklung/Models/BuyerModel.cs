namespace Hahn_Softwareentwicklung.Models
{
    public class BuyerModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Budget { get; set; }
        public IList<OrderModel> Orders { get; set; }

        public BuyerModel(Guid id, string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, float budget, IList<OrderModel> orders)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Budget = budget;
            Orders = orders;
        }
    }
}
