namespace Hahn_Softwareentwicklung.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public BuyerModel Buyer { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<OrderItemModel> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
        public ShippingAddressModel ShippingAddress { get; set; }

        public OrderModel(Guid id, BuyerModel buyer, DateTime orderDate, List<OrderItemModel> orderItems, string paymentMethod, OrderStatus status, ShippingAddressModel shippingAddress)
        {
            Id = id;
            Buyer = buyer;
            OrderItems = orderItems;
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            TotalAmount = orderItems.Sum(x => x.Car.Price * x.Quantity);
            Status = status;
            ShippingAddress = shippingAddress;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }
    }

    
}