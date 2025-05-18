using AutoMapper;
using Domain.Entities.UserTransaction;

namespace Application.Mappings;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Domain.Entities.UserTransaction.UserTransaction, TransactionDto>()
            .ForMember(dest => dest.CurrencySymbol, opt => opt.MapFrom(src => src.Currency.Symbol))
            .ForMember(dest => dest.ScenarioName, opt => opt.MapFrom(src => src.Scenario.Name))
            .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.Event.Title));
    }
}