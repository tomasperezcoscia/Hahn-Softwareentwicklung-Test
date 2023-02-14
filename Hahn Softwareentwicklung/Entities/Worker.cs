using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }   
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Worker(string name, string email, string phoneNumber, string position, decimal salary)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = name+phoneNumber.ToString();
            Position = position;
            Salary = salary;
        }
    }
}
