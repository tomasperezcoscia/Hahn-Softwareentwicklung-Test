﻿using System.ComponentModel.DataAnnotations.Schema;


namespace Hahn_Softwareentwicklung.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Guid carId, int quantity, Guid orderId)
        {
            Id = Guid.NewGuid();
            CarId = carId;
            Quantity = quantity;
            OrderId = orderId;
        }
    }
}

