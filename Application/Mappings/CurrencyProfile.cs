using AutoMapper;
using Domain.Entities.Currency;

namespace Application.Mappings;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<Domain.Entities.Currency.Currency, CurrencyDto>()
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