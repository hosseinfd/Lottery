using System.Net;
using Domain.Common;

namespace Domain.Exceptions;

public class NotFoundException : ServiceException
{
    public NotFoundException(List<ValidationItem> validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.NotFound;
    }

    public NotFoundException(ValidationItem validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}