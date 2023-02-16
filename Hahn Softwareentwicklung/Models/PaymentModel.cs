namespace Hahn_Softwareentwicklung.Models
{
    public class PaymentModel
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
        public PaymentModel(Guid id, decimal amount, PaymentMethodModel paymentMethod) {
            Id = id;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
