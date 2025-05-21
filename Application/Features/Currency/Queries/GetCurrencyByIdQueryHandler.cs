using Application.BuildingBlocks.CQRS.Queries;
using Domain.Entities.Currency;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Queries;

public class GetCurrencyByIdQueryHandler: IQueryHandler<CurrencyQueries.GetCurrencyByIdQuery, CurrencyDto?>
{
    private readonly ICurrencyReadRepository _currencyReadRepository;

    public GetCurrencyByIdQueryHandler(ICurrencyReadRepository currencyReadRepository)
    {
        _currencyReadRepository = currencyReadRepository;
    }

    public async Task<CurrencyDto?> Handle(CurrencyQueries.GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        var currency = await _currencyReadRepository.GetByIdAsync(request.CurrencyId,cancellationToken);
        return currency is null ? null : currency.MapToDto();
    }
}