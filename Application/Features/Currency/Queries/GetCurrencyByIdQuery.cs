using Application.BuildingBlocks.CQRS.Queries;
using AutoMapper;
using Domain;
using Domain.Entities.Currency;
using Domain.Exceptions;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Queries;

public sealed record GetCurrencyByIdQuery(Guid CurrencyId) : IQuery<CurrencyDto?>;

internal sealed class GetCurrencyByIdQueryHandler(ICurrencyReadRepository currencyReadRepository, IMapper mapper)
    : IQueryHandler<GetCurrencyByIdQuery, CurrencyDto?>
{
    public async Task<CurrencyDto?> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        var currency = await currencyReadRepository.GetByIdAsync(request.CurrencyId, cancellationToken);
        if (currency == null)
            throw new ServiceException(new ValidationItem(nameof(request.CurrencyId), "Currency for this id not found", "20010"));
        return mapper.Map<CurrencyDto>(currency);
    }
}