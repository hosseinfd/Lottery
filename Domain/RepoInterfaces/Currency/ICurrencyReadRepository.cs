using Domain.Interfaces;

namespace Domain.RepoInterfaces.Currency;

public interface ICurrencyReadRepository : IReadRepository<Entities.Currency.CurrencyDao>
{
}