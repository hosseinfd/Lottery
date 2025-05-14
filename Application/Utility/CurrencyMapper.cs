using Domain.Currency;

namespace Application.Utility;

public static class CurrencyMapper
{
    public static CurrencyDto MapToDto(this Domain.Currency.Currency currency) => new CurrencyDto
    {
        CurrencyId = currency.CurrencyId,
        Name = currency.Name,
        Symbol = currency.Symbol
    };
}