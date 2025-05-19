using Domain.Common.EntityAttributeInterfaces;
using Domain.Entities.Currency;
using Domain.Entities.User;

namespace Domain.Entities.UserBalance;

public class UserBalanceDao : ICreated, ISoftDeleted
{
    public Guid BalanceId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CurrencyId { get; private set; }
    public decimal Balance { get; private set; }
    public UserDao UserDao { get; private set; }
    public CurrencyDao CurrencyDao { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public DateTime? DeactivatedAt { get; set; }
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