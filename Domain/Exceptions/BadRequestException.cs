using System.Net;

namespace Domain.Exceptions;

public class BadRequestException : ServiceException
{
    public BadRequestException(List<ValidationItem> validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }

    public BadRequestException(ValidationItem validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}