using System.Net;

namespace Domain.Exceptions;

public class DuplicateEntryException : ServiceException
{
    public DuplicateEntryException(List<ValidationItem> validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }

    public DuplicateEntryException(ValidationItem validationItem, object? data = null) : base(validationItem, data)
    {
        StatusCode = HttpStatusCode.UnprocessableEntity;
    }
}