using Application.BuildingBlocks.CQRS.Commands;

namespace Application.Currency.Commands;

public class CurrencyCommands
{
    public record CreateCurrencyCommand(string Name, string Symbol) : ICommand<Guid>;
    public record UpdateCurrencyCommand(Guid CurrencyId, string Name, string Symbol) : ICommand<bool>;
    public record DeleteCurrencyCommand(Guid CurrencyId) : ICommand<bool>;
}