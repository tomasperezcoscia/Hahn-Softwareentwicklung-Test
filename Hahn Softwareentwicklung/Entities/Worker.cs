namespace Hahn_Softwareentwicklung.Entities
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Worker(string name, string email, string phoneNumber, string position, decimal salary)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Position = position;
            Salary = salary;
        }
    }
}
