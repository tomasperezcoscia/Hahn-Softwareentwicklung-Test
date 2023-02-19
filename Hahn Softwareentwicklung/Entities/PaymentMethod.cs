using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PaymentMethod() { }
        public PaymentMethod(string name)
        {
            Name = name;
        }
    }
}
