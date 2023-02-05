namespace Hahn_Softwareentwicklung.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Payment(decimal amount, PaymentMethod paymentMethod) {
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
