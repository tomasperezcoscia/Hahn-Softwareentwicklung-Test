using FluentValidation;
using Hahn_Softwareentwicklung.Models;

namespace Hahn_Softwareentwicklung.Validators
{
    public class BuyerValidator : AbstractValidator<BuyerModel>
    {
        public BuyerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                .EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required")
                                       .Length(10, 15).WithMessage("Phone number must be between 10 and 15 characters");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth is required")
                                        .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past");
            RuleFor(x => x.Budget).NotEmpty().WithMessage("Budget is required")
                                  .GreaterThan(0).WithMessage("Budget must be greater than 0");
            RuleFor(x => x.Interests).NotEmpty().WithMessage("Interests are required");
        }
    }
}