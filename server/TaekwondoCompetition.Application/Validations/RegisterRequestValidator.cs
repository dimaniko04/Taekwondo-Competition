using FluentValidation;
using TaekwondoCompetition.Application.Requests;

namespace TaekwondoCompetition.Application.Validations;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Matches(@"^[A-Za-z]+$").WithMessage("First name can only contain letters.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Matches(@"^[A-Za-z]+$").WithMessage("Last name can only contain letters.");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Now).WithMessage("Birth date must be in the past.")
            .GreaterThanOrEqualTo(DateTime.Now.AddYears(-120)).WithMessage("Birth date cannot be more than 120 years ago.");

        RuleFor(x => x.Sex)
            .IsInEnum().WithMessage("Invalid sex value.");
    }
}