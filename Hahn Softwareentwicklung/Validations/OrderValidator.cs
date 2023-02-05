using FluentValidation;
using Hahn_Softwareentwicklung.Models;

namespace Hahn_Softwareentwicklung.Validators
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.Buyer).SetValidator(new BuyerValidator());
            RuleFor(x => x.OrderDate).NotEmpty();
            RuleFor(x => x.OrderItems).NotEmpty();
            RuleFor(x => x.TotalAmount).NotEmpty();
            RuleFor(x => x.Payment).SetValidator(new PaymentValidator());
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.ShippingAddress).SetValidator(new ShippingAddressValidator());
        }
    }
}