﻿namespace Hahn_Softwareentwicklung.Entities
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public float Budget { get; set; }
        public List<string> Interests { get;set; }
    }
}
