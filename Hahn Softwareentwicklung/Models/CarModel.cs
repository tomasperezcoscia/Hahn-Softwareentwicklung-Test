namespace Hahn_Softwareentwicklung.Models
{ 
    public class CarModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        public CarModel(Guid id, string brand, string model, int year, decimal price, string color)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            Color = color;
        }
    }
}
