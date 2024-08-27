using FluentValidation;

namespace Core.Requests_Handlers.Validations.FluentValidations
{
    public class AddAccountValidator : AbstractValidator<AddAccountRequest>
    {
        public AddAccountValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty()
                .WithMessage("Token is required");

            RuleFor(x => x.WebsiteName)
                .NotEmpty()
                .WithMessage("Website name is required");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
