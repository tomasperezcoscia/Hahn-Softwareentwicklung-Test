namespace Hahn_Softwareentwicklung.Models
{ 
    public class CarModel
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        public CarModel(string brand, string model, int year, decimal price, string color)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            Color = color;
        }
    }
}
