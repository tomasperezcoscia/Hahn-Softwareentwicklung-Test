namespace Hahn_Softwareentwicklung.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Car Car { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderItem(Car car, int quantity) {
            Car = car;
            Quantity = quantity;
            UnitPrice = car.Price;
        }
    }
}
