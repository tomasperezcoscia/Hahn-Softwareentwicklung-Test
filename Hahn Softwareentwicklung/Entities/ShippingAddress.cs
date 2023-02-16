using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class ShippingAddress
    {
        public Guid ShippingAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public ShippingAddress(string addressLine1, string addressLine2, string city, string state, string postalCode, string country, Guid orderId)
        {
            ShippingAddressId = Guid.NewGuid();
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            OrderId = orderId;
        }
    }
}
