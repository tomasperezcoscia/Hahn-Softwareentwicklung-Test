namespace Hahn_Softwareentwicklung.Models
{
    public class PaymentMethodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentMethodModel(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public enum PaymentMethods
        {
            None,
            CreditCard,
            DebitCard,
            NetBanking,
            UPI,
            Wallet
        }
    }
}
