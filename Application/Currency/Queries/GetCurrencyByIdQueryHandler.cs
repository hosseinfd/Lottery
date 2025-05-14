using Application.BuildingBlocks.CQRS.Queries;
using Application.Utility;
using Domain.Currency;
using Domain.RepoInterfaces.Currency;

namespace Application.Currency.Queries;

public class GetCurrencyByIdQueryHandler: IQueryHandler<CurrencyQueries.GetCurrencyByIdQuery, CurrencyDto?>
{
    private readonly ICurrencyReadRepository _currencyReadRepository;

    public GetCurrencyByIdQueryHandler(ICurrencyReadRepository currencyReadRepository)
    {
        _currencyReadRepository = currencyReadRepository;
    }

    public async Task<CurrencyDto?> Handle(CurrencyQueries.GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        var currency = await _currencyReadRepository.GetByIdAsync(request.CurrencyId);
        return currency is null ? null : currency.MapToDto();
    }
}