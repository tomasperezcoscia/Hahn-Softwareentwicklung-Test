﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        public Car(string brand, string model, int year, decimal price, string color)
        {
            CarID = Guid.NewGuid();
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            Color = color;
        }
    }
}
