using Application.BuildingBlocks.CQRS.Commands;
using Domain.Entities.Currency;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Commands;

public sealed record CreateCurrencyCommand(string Name, string Symbol) : ICommand<Guid>;

internal sealed class CreateCurrencyCommandHandler(ICurrencyWriteRepository currencyWriteRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCurrencyCommand, Guid>
{
    public async Task<Guid> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = new CurrencyDao
        {
            CurrencyId = Guid.NewGuid(),
            Name = request.Name,
            Symbol = request.Symbol
        };

        currencyWriteRepository.Add(currency, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return currency.CurrencyId;
    }
}