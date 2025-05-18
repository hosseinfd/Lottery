using Application.BuildingBlocks.CQRS.Queries;
using Domain.Entities.Currency;

namespace Application.Features.Currency.Queries;

public class CurrencyQueries
{
    public record GetCurrencyByIdQuery(Guid CurrencyId) : IQuery<CurrencyDto?>;
    public record GetAllCurrenciesQuery() : IQuery<List<CurrencyDto>>;
}