namespace Domain.Services;

public class RewardResult
{
    public decimal AmountAwarded { get; }
    public string CurrencySymbol { get; }
    public decimal NewBalance { get; }
    public Guid TransactionId { get; }
    public DateTime AwardedAt { get; }

    public RewardResult(decimal amountAwarded, string currencySymbol, 
        decimal newBalance, Guid transactionId)
    {
        AmountAwarded = amountAwarded;
        CurrencySymbol = currencySymbol;
        NewBalance = newBalance;
        TransactionId = transactionId;
        AwardedAt = DateTime.UtcNow;
    }
}