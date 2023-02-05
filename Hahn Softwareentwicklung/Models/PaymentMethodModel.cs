namespace Hahn_Softwareentwicklung.Models
{
    public class PaymentMethodModel
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
        public PaymentMethodModel(string name)
        {
            Name = name;
        }
    }
}
