using Hahn_Softwareentwicklung.Entities;
using FluentValidation;

namespace Hahn_Softwareentwicklung.Validations;

public class WorkerValidator : AbstractValidator<Worker>
{
    public WorkerValidator()
    {
        RuleFor(worker => worker.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(worker => worker.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(worker => worker.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
        RuleFor(worker => worker.Email).EmailAddress().WithMessage("Invalid email address.");
        RuleFor(worker => worker.Salary).GreaterThan(0).WithMessage("Salary must be greater than 0.");
    }
}