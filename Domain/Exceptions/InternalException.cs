using System.Net;

namespace Domain.Exceptions;

public class InternalException : Exception
{
    public InternalException(string status, string message)
    {
        Message = message;
    }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

    public override string Message { get; }
}