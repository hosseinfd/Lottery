namespace Domain.Exceptions;

public class UserAlreadyExistException : BadRequestException
{
    public UserAlreadyExistException(List<ValidationItem>? validationItem = null, object? data = null) : base(validationItem, data)
    {
    }

    public UserAlreadyExistException(ValidationItem validationItem, object? data = null) : base(validationItem, data)
    {
    }
}