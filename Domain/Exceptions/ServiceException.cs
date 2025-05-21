using System.Net;
using Domain.Common;

namespace Domain.Exceptions
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.UnprocessableEntity;

        public ServiceException(List<ValidationItem> validationItem, object? data = null)
        {
            Result = Result<object>.Failed(validationItem, data);
        }

        public ServiceException(ValidationItem validationItem, object? data = null)
        {
            var validationItems = new List<ValidationItem>
            {
                validationItem
            };
            Result = Result<object>.Failed(validationItems, data);
        }

        public Result<object> Result { get; }
    }
}