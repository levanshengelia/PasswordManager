using Core.Enums;
using Core.Responses.Contracts;
using FluentValidation;
using MediatR;

namespace Core.RequestValidations.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : IResponseResult, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            var response = new TResponse
            {
                Status = ResponseStatus.Fail,
                ErrorMessage = string.Join(",\n ", failures.Select(f => f.ErrorMessage))
            };

            return response;
        }

        return await next();
    }
}
