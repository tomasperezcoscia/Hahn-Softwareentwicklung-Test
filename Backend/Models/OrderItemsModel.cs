namespace Hahn_Softwareentwicklung.Models
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public CarModel Car { get; set; }
        public int Quantity { get; set; }

        public OrderItemModel(Guid id, CarModel car, int quantity, Guid fromOrder)
        {
            Id = id;
            Car = car;
            Quantity = quantity;
        }
    }
}
