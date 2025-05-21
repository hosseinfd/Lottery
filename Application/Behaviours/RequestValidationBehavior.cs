using Domain;
using Domain.Common;
using FluentValidation;
using MediatR.Pipeline;
using ValidationException = Domain.Exceptions.ValidationException;

namespace Application.Behaviours;

public class RequestValidationBehavior<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {  
        cancellationToken.ThrowIfCancellationRequested();

        if (!_validators.Any()) return;

        var context = new ValidationContext<TRequest>(request);

        // Assuming there's an asynchronous version of the Validate method
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(r => new ValidationItem(r.PropertyName, r.ErrorMessage,r.ErrorCode))
            .ToList();

        if (failures.Count != 0) throw new ValidationException(failures);
    }
}