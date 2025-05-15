using Domain.Entities.Currency;
using Domain.Interfaces;

namespace Domain.RepoInterfaces.Currency;

public interface ICurrencyReadRepository : IReadRepository<CurrencyDao>
{
}