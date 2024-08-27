using FluentValidation;

namespace Core.Requests_Handlers.Validations.FluentValidations
{
    public class GetUserAccountsValidator : AbstractValidator<GetUserAccountsRequest>
    {
        public GetUserAccountsValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty()
                .WithMessage("Token is required");
        }
    }
}
