namespace Domain.Exceptions;

public class NullOrEmptyException : ArgumentException
{
    public NullOrEmptyException(string paramName)
        : base($"{paramName} cannot be null or empty", paramName)
    {
    }
}

public class EmptyListException : ArgumentException
{
    public EmptyListException(string paramName)
        : base($"{paramName} cannot be null or empty", paramName)
    {
    }
}

public class InvalidEmailFormatException : ArgumentException
{
    public InvalidEmailFormatException()
        : base("Invalid email format")
    {
    }
}

public class InvalidPhoneNumberException : ArgumentException
{
    public InvalidPhoneNumberException()
        : base("Invalid phone number format")
    {
    }
}

public class FutureDateException : ArgumentException
{
    public FutureDateException(string paramName)
        : base($"{paramName} cannot be in the future", paramName)
    {
    }
}

public class StringTooLongException : ArgumentException
{
    public StringTooLongException(string paramName, int maxLength)
        : base($"{paramName} cannot exceed {maxLength} characters", paramName)
    {
    }
}
