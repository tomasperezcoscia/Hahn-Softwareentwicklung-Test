using System.ComponentModel.DataAnnotations.Schema;


namespace Hahn_Softwareentwicklung.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string CarDescription { get; set; }
        public int Quantity { get; set; }
        public string PriceText { get; set; }
        public string TotalText { get; set; }

        public OrderItem(Guid id, Guid carId,int quantity, string carDescription, string priceText, string totalText)
        {
            Id = id;
            CarId = carId;
            Quantity = quantity;
            CarDescription = carDescription;
            PriceText = priceText;
            TotalText = totalText;
        }
    }
}

