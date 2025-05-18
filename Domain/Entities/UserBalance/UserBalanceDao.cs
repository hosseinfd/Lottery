using Domain.Entities.Currency;
using Domain.Entities.User;

namespace Domain.Entities.UserBalance;

public class UserBalanceDao
{
    public Guid BalanceId { get; }
    public Guid UserId { get; }
    public Guid CurrencyId { get; }
    public decimal Balance { get; }
    public DateTime UpdatedAt { get; }
    public DateTime CreatedAt { get; }
    public UserDao UserDao { get; }
    public CurrencyDao CurrencyDao { get; }


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