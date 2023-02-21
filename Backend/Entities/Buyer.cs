using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Buyer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public float Budget { get; set; }

        public Buyer(string firstName, string lastName, string email, string phoneNumber, string dateOfBirth, float budget)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Budget = budget;
        }
    }
}
