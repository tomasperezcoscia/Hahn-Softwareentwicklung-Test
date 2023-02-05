namespace Hahn_Softwareentwicklung.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Buyer Buyer { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public Payment Payment { get; set; }
        public OrderStatus Status { get; set; }
        public ShippingAddress ShippingAddress { get; set; }

        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        public Order(Buyer customer, List<OrderItem> orderItems, Payment payment)
        {
            OrderId = Guid.NewGuid();
            Buyer = customer;
            OrderItems = orderItems;
            Payment = payment;
            TotalAmount = orderItems.Sum(x => x.UnitPrice * x.Quantity);
            Status = OrderStatus.Pending;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        
    }


}
