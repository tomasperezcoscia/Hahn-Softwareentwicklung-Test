using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Payment(decimal amount, int paymentMethodId, Guid orderId)
        {
            PaymentId = Guid.NewGuid();
            Amount = amount;
            PaymentMethodId = paymentMethodId;
            OrderId = orderId;
        }
    }
}
