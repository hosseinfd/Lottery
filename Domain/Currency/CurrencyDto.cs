namespace Domain.Currency;

public class CurrencyDto
{
    public Guid CurrencyId { get; set; }
    public string Name { get; set; } = default!;
    public string Symbol { get; set; } = default!;
}