using Domain.Services;

namespace Domain.Entities.Currency;

public class CurrencyDao : Entity
{
    public Guid CurrencyId { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
}