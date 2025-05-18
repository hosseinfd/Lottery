using System.Net;
using Domain.Common;

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