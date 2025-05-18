using AutoMapper;
using Domain.Entities.Currency;

namespace Application.Mappings;

public sealed class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<CurrencyDao, CurrencyDto>()
            .ConvertUsing(currency =>
                new CurrencyDto
                {
                    CurrencyId = currency.CurrencyId,
                    Name = currency.Name,
                    Symbol = currency.Symbol
                }
            );
    }
}