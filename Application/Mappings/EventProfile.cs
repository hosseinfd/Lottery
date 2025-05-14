using AutoMapper;
using Domain.Event;
using Domain.Event.Dto;

namespace Application.Mappings;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Domain.Event.Event, EventDto>()
            .ForMember(dest => dest.IsParticipating, opt => opt.Ignore())
            .ForMember(dest => dest.TotalParticipants, opt => opt.MapFrom(src => src.Participations.Count))
            .ForMember(dest => dest.EventRules, opt => opt.MapFrom(src => src.EventRules));

        CreateMap<Scenario, ScenarioDto>()
            .ForMember(dest => dest.RewardCurrencySymbol, opt => opt.MapFrom(src => src.RewardCurrency.Symbol))
            .ForMember(dest => dest.AdditionalData, opt => opt.MapFrom(src => src.AdditionalData));

        CreateMap<EventParticipation, EventParticipationDto>();
    }
}