using Application.BuildingBlocks.CQRS.Queries;
using Domain;
using Domain.Entities.Event.Dto;
using Domain.Exceptions;
using Domain.RepoInterfaces.Event;

namespace Application.Features.Event.Queries;

public class GetEventDetailsQueryHandler: IQueryHandler<EventQueries.GetEventDetailsQuery, EventDto>
{
    private readonly IEventReadRepository _eventReadRepo;
    private readonly IParticipationReadRepository _participationReadRepo;
    
    public GetEventDetailsQueryHandler(
        IEventReadRepository eventReadRepo,
        IParticipationReadRepository participationReadRepo)
    {
        _eventReadRepo = eventReadRepo;
        _participationReadRepo = participationReadRepo;
    }

    public async Task<EventDto> Handle(EventQueries.GetEventDetailsQuery request, CancellationToken ct)
    {
        var eventDto = await _eventReadRepo.GetByIdAsync(request.EventId, ct)
                       ?? throw new EventException(new ValidationItem(null,"Event not found",null));
            
        var participation = await _participationReadRepo.GetAsync(request.UserId, request.EventId, ct);
        
        eventDto.IsParticipating = participation != null;
        return eventDto;
    }
}