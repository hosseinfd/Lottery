using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Commands;

public sealed record UpdateCurrencyCommand(Guid CurrencyId, string Name, string Symbol) : ICommand<bool>;

internal sealed class UpdateCurrencyCommandHandler(
    ICurrencyReadRepository currencyReadRepository,
    ICurrencyWriteRepository currencyWriteRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCurrencyCommand, bool>
{
    public async Task<bool> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = await currencyReadRepository.GetByIdAsync(request.CurrencyId, cancellationToken);
        if (currency == null) return false;

        currency.Name = request.Name;
        currency.Symbol = request.Symbol;

        currencyWriteRepository.Update(currency);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}