using Core.Requests;
using FluentValidation;

namespace Core.RequestValidations.FluentValidations
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequest>
    {
        private const int StrongPasswordConditionCount = 3;

        public RegistrationValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email is invalid");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .MinimumLength(8)
                .WithMessage("Password should be minimum of 8 characters")
                .Must(BeStrongPassword)
                .WithMessage($"Password is weak, satisfy at least {StrongPasswordConditionCount} out of these 4: " +
                    "use at least one uppercase character, use at least one lowercase character" +
                    "use at least one symbol, use at least one digit");

            RuleFor(x => x.ConfirmedPassword)
                .Equal(x => x.Password)
                .WithMessage("Password don't match");
        }

        private bool BeStrongPassword(string password)
        {
            var hasValidLength = password.Length >= 8;

            var containsLowerCase = password.Any(char.IsLower);
            var containsUpperCase = password.Any(char.IsUpper);
            var containsSymbol = password.Any(char.IsPunctuation);
            var containsNumber = password.Any(char.IsDigit);

            bool[] conditions =
            {
                containsLowerCase,
                containsUpperCase,
                containsSymbol,
                containsNumber,
            };

            int conditionsMet = conditions.Count(condition => condition);

            return hasValidLength && conditionsMet >= 3;
        }
    }
}
