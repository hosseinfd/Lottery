using Domain.Common.EntityAttributeInterfaces;

namespace Domain.Entities.Currency;

public class CurrencyDao : ISoftDeleted
{
    public Guid CurrencyId { get; private set; }
    public string Name { get; private set; }
    public string Symbol { get; private set; }
    public bool IsActive { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}