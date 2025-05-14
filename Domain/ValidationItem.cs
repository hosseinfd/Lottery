using System.Diagnostics.CodeAnalysis;

namespace Domain;

public class ValidationItem
{
    // public ValidationItem(string propertyName, string errorMessage, string errorCode)
    // {
    //     PropertyName = propertyName;
    //     ErrorCode = errorCode;
    //     ErrorMessage = errorMessage;
    // }
    [SetsRequiredMembers]
    public ValidationItem(string propertyName, string errorMessage, string errorCode) =>
        (PropertyName,  ErrorMessage,  ErrorCode) = (propertyName,  errorMessage,  errorCode);

    // public required string PropertyName { get; set; }
    // public required string ErrorCode { get; set; }
    // public required string ErrorMessage { get; set; }
    
    public required string PropertyName { get; set; }
    public required string ErrorCode { get; set; }
    public required string ErrorMessage { get; set; }
}