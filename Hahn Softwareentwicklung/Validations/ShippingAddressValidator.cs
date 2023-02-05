using FluentValidation;
using Hahn_Softwareentwicklung.Models;

namespace Hahn_Softwareentwicklung.Validators
{
    public class ShippingAddressValidator : AbstractValidator<ShippingAddressModel>
    {
        public ShippingAddressValidator()
        {
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Address Line 1 is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is required");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal Code is required");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required");
        }
    }
}