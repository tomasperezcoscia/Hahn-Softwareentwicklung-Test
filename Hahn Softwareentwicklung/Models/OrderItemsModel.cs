namespace Hahn_Softwareentwicklung.Models
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public CarModel Car { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderItemModel(CarModel car, int quantity, Guid fromOrder)
        {
            Car = car;
            Quantity = quantity;
            UnitPrice = car.Price;
        }
    }
}
