using Application.BuildingBlocks.CQRS.Queries;
using AutoMapper;
using Domain.Entities.Currency;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Queries;

public sealed record GetAllCurrenciesQuery : IQuery<List<CurrencyDto>>;

public class GetAllCurrenciesQueryHandler(ICurrencyReadRepository currencyReadRepository, IMapper mapper)
    : IQueryHandler<GetAllCurrenciesQuery, List<CurrencyDto>>
{
    public async Task<List<CurrencyDto>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var currencies = await currencyReadRepository.GetAllAsync(cancellationToken);
        return currencies
            .Select(mapper.Map<CurrencyDto>)
            .ToList();
    }
}