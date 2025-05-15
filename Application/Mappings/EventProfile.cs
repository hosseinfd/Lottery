using AutoMapper;
using Domain.Entities.Event;
using Domain.Entities.Event.Dto;
using Domain.Event;

namespace Application.Mappings;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<EventDao, EventDto>()
            .ForMember(dest => dest.IsParticipating, opt => opt.Ignore())
            .ForMember(dest => dest.TotalParticipants, opt => opt.MapFrom(src => src.Participations.Count))
            .ForMember(dest => dest.EventRules, opt => opt.MapFrom(src => src.EventRules));

        CreateMap<ScenarioDao, ScenarioDto>()
            .ForMember(dest => dest.RewardCurrencySymbol, opt => opt.MapFrom(src => src.RewardCurrency.Symbol))
            .ForMember(dest => dest.AdditionalData, opt => opt.MapFrom(src => src.AdditionalData));

        CreateMap<EventParticipationDao, EventParticipationDto>();
    }
}