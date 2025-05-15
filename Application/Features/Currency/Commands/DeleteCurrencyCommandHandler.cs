using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Commands;

public sealed record DeleteCurrencyCommand(Guid CurrencyId) : ICommand<bool>;

internal sealed class DeleteCurrencyCommandHandler(
    ICurrencyReadRepository currencyReadRepository,
    ICurrencyWriteRepository currencyWriteRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCurrencyCommand, bool>
{
    public async Task<bool> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = await currencyReadRepository.GetByIdAsync(request.CurrencyId, cancellationToken);
        if (currency == null) return false;

        currencyWriteRepository.Delete(currency);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}