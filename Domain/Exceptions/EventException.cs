namespace Domain.Exceptions;

public class EventException : NotFoundException
{
    public EventException(List<ValidationItem> validationItem, object? data = null) : base(validationItem, data)
    {
    }

    public EventException(ValidationItem validationItem, object? data = null) : base(validationItem, data)
    {
    }
}