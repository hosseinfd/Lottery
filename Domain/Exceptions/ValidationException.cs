using System.Net;

namespace Domain.Exceptions;

public class ValidationException : ServiceException
{
    public ValidationException(List<ValidationItem> validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }

    public ValidationException(ValidationItem validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}