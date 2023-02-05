namespace Hahn_Softwareentwicklung.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
        public PaymentMethod(string name)
        {
            Name = name;
        }
    }
}
