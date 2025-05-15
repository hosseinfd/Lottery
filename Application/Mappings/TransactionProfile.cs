using AutoMapper;
using Domain.Entities.UserTransaction;

namespace Application.Mappings;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<TransactionDao, TransactionDto>()
            .ForMember(dest => dest.CurrencySymbol, opt => opt.MapFrom(src => src.CurrencyDao.Symbol))
            .ForMember(dest => dest.ScenarioName, opt => opt.MapFrom(src => src.Scenario.Name))
            .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.EventDao.Title));
    }
}