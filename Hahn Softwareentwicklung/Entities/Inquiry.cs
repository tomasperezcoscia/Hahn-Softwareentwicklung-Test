namespace Hahn_Softwareentwicklung.Entities
{
    public class Inquiry
    {
        public int InquiryID { get; set; }
        public string InquiryString { get; set; }
        public Buyer Buyer { get; set; }
        public Inquiry(string inquiryString, Buyer buyer)
        {
            InquiryString = inquiryString;
            Buyer = buyer;
        }
    }
}
