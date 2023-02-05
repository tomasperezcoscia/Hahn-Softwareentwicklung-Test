﻿namespace Hahn_Softwareentwicklung.Models
{
    public class ShippingAddressModel
    {
        public int ShippingAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
