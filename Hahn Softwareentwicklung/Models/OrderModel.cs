namespace Hahn_Softwareentwicklung.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public BuyerModel Buyer { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<OrderItemModel> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentModel Payment { get; set; }
        public OrderStatusModel Status { get; set; }
        public ShippingAddressModel ShippingAddress { get; set; }

        public OrderModel(BuyerModel buyer, List<OrderItemModel> orderItems, PaymentModel payment, ShippingAddressModel shippingAddress)
        {
            OrderId = Guid.NewGuid();
            Buyer = buyer;
            OrderItems = orderItems;
            OrderDate = DateTime.Now;
            Payment = payment;
            TotalAmount = orderItems.Sum(x => x.UnitPrice * x.Quantity);
            Status = OrderStatusModel.Pending;
            ShippingAddress = shippingAddress;
        }

        public void UpdateStatus(OrderStatusModel newStatus)
        {
            Status = newStatus;
        }
    }

    public enum OrderStatusModel
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}