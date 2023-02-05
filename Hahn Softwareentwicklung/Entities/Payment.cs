﻿namespace Hahn_Softwareentwicklung.Entities
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentModel(decimal amount, PaymentMethod paymentMethod) {
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
