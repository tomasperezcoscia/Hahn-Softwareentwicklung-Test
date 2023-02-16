using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

        [ForeignKey("Buyer")]
        public Guid BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        public OrderStatus Status { get; set; }

        [ForeignKey("ShippingAddress")]
        public Guid ShippingAddressId { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }

        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        public Order(Guid buyerId, Guid paymentId, Guid shippingAddressId)
        {
            OrderId = Guid.NewGuid();
            OrderDate = DateTime.Now;
            BuyerId= buyerId;
            OrderItems = new List<OrderItem>();
            Status = OrderStatus.Pending;
            PaymentId= paymentId;
            ShippingAddressId = shippingAddressId;
            TotalAmount = getTotalAmount(OrderItems);
        }

        public void addOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void removeOrderItem(OrderItem orderItem) { 
            OrderItems.Remove(orderItem); 
        }

        public decimal getTotalAmount(List<OrderItem> orderItems)
        {
            decimal totalAmount = 0;

            using (var context = new ApplicationContext())
            {
                foreach (var item in orderItems)
                {
                    var orderItem = context.OrderItems.Find(item);
                    totalAmount += orderItem.Quantity * orderItem.UnitPrice;
                }
            }

            return totalAmount;
        }

    }
}
