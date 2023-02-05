using FluentValidation;
using Hahn_Softwareentwicklung.Models;

namespace Hahn_Softwareentwicklung.Validators
{
    public class PaymentValidator : AbstractValidator<PaymentModel>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
            //Change this so it works with the NONE payment method
            RuleFor(x => x.PaymentMethod)
                .NotEqual(PaymentMethodModel.None)
                .WithMessage("Payment method is required.");
        }
    }
}