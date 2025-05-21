using Application.BuildingBlocks.CQRS.Queries;
using Domain.Entities.Currency;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Queries;

public class GetAllCurrenciesQueryHandler : IQueryHandler<CurrencyQueries.GetAllCurrenciesQuery, List<CurrencyDto>>
{
    private readonly ICurrencyReadRepository _currencyReadRepository;

    public GetAllCurrenciesQueryHandler(ICurrencyReadRepository currencyReadRepository)
    {
        _currencyReadRepository = currencyReadRepository;
    }

    public async Task<List<CurrencyDto>> Handle(CurrencyQueries.GetAllCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var currencies = await _currencyReadRepository.GetAllAsync();
        return currencies.Select(c => new CurrencyDto
        {
            CurrencyId = c.CurrencyId,
            Name = c.Name,
            Symbol = c.Symbol
        }).ToList();    }
}