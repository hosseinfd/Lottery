using Application.BuildingBlocks.CQRS.Commands;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Currency;

namespace Application.Currency.Commands;

public class UpdateCurrencyCommandHandler: ICommandHandler<CurrencyCommands.UpdateCurrencyCommand, bool>
{
    private readonly ICurrencyWriteRepository _currencyWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCurrencyCommandHandler(ICurrencyWriteRepository currencyWriteRepository, IUnitOfWork unitOfWork)
    {
        _currencyWriteRepository = currencyWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CurrencyCommands.UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = await _currencyWriteRepository.GetByIdAsync(request.CurrencyId,cancellationToken);
        if (currency == null) return false;

        currency.Name = request.Name;
        currency.Symbol = request.Symbol;

        _currencyWriteRepository.Update(currency);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}