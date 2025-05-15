using System.Diagnostics.CodeAnalysis;

namespace Domain;

[method: SetsRequiredMembers]
public class ValidationItem(string propertyName, string errorMessage, string errorCode)
{
    public required string PropertyName { get; set; } = propertyName;
    public required string ErrorCode { get; set; } = errorCode;
    public required string ErrorMessage { get; set; } = errorMessage;
}