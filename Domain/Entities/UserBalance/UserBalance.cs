namespace Domain.Entities.UserBalance;

public class UserBalance
{
    public Guid BalanceId { get; set; }
    public Guid UserId { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal Balance { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public Entities.User.User User { get; set; }
    public Entities.Currency.Currency Currency { get; set; }
    
    
    // Domain methods
    // public void Credit(decimal amount)
    // {
    //     if (amount <= 0)
    //         throw new DomainException("Credit amount must be positive");
    //         
    //     Balance += amount;
    //     UpdatedAt = DateTime.UtcNow;
    //     
    //     AddDomainEvent(new BalanceUpdatedEvent(UserId, CurrencyId, Balance));
    // }
    //
    // public void Debit(decimal amount)
    // {
    //     if (amount <= 0)
    //         throw new DomainException("Debit amount must be positive");
    //         
    //     if (Balance < amount)
    //         throw new DomainException("Insufficient balance");
    //         
    //     Balance -= amount;
    //     UpdatedAt = DateTime.UtcNow;
    //     
    //     AddDomainEvent(new BalanceUpdatedEvent(UserId, CurrencyId, Amount));
    // }
}