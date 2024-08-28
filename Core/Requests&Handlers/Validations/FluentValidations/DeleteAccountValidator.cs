using FluentValidation;

namespace Core.Requests_Handlers.Validations.FluentValidations
{
    public class DeleteAccountValidator : AbstractValidator<DeleteAccountRequest>
    {
        public DeleteAccountValidator()
        {
        }
    }
}
