using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        

        
        public Payment(decimal amount, int paymentMethodId, Guid orderId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            PaymentMethodId = paymentMethodId;
            OrderId = orderId;
        }
    }
}
