namespace Domain.Entities.UserBalance;

public class UserBalanceDto
{
    public decimal Amount { get; set; }
    public string CurrencySymbol { get; set; }
    public string CurrencyName { get; set; }
}