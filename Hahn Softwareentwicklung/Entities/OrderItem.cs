using System.ComponentModel.DataAnnotations.Schema;


namespace Hahn_Softwareentwicklung.Entities
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public OrderItem(Guid carId, int quantity, Guid orderId)
        {
            OrderItemId = Guid.NewGuid();
            CarId = carId;
            Quantity = quantity;
            OrderId = orderId;
        }
    }
}

