using Application.BuildingBlocks.CQRS.Commands;
using Domain.Interfaces;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Currency;

namespace Application.Currency.Commands;

public class DeleteCurrencyCommandHandler: ICommandHandler<CurrencyCommands.DeleteCurrencyCommand, bool>
{
    private readonly ICurrencyWriteRepository _currencyWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCurrencyCommandHandler(ICurrencyWriteRepository currencyWriteRepository, IUnitOfWork unitOfWork)
    {
        _currencyWriteRepository = currencyWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CurrencyCommands.DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = await _currencyWriteRepository.GetByIdAsync(request.CurrencyId,cancellationToken);
        if (currency == null) return false;

        _currencyWriteRepository.Delete(currency);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
    
}