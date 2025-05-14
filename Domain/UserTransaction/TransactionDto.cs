namespace Domain.UserTransaction;

public class TransactionDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string CurrencySymbol { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? EventId { get; set; }
    public string? EventTitle { get; set; }
}