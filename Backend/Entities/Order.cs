using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Buyer")]
        public Guid? BuyerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }

        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        public Order(Guid? buyerId, decimal totalAmount, string paymentMethod)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;
            BuyerId = buyerId;
            Status = OrderStatus.Pending;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
        }
    }
}
