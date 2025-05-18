using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Currency;

namespace Application.Features.Currency.Commands;

public class CreateCurrencyCommandHandler : ICommandHandler<CurrencyCommands.CreateCurrencyCommand, Guid>
{
    private readonly ICurrencyWriteRepository _currencyWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCurrencyCommandHandler(ICurrencyWriteRepository currencyWriteRepository, IUnitOfWork unitOfWork)
    {
        _currencyWriteRepository = currencyWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CurrencyCommands.CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = new Domain.Entities.Currency.Currency
        {
            CurrencyId = Guid.NewGuid(),
            Name = request.Name,
            Symbol = request.Symbol
        };

        await _currencyWriteRepository.AddAsync(currency,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return currency.CurrencyId;
    }
}