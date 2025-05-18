namespace Domain.Entities.UserTransaction;

public class TransactionDto
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public string CurrencySymbol { get; }
    public string Type { get; }
    public string Description { get; }
    public DateTime CreatedAt { get; }
    public Guid? EventId { get; }
    public string? EventTitle { get; }
}