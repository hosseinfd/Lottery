using Domain.Interfaces;

namespace Domain.RepoInterfaces.Currency;

public interface ICurrencyWriteRepository : IWriteRepository<Entities.Currency.Currency>
{
}