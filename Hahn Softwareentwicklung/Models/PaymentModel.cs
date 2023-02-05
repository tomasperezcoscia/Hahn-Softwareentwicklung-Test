namespace Hahn_Softwareentwicklung.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
        public PaymentModel(decimal amount, PaymentMethodModel paymentMethod) {
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
