using Application.BuildingBlocks.CQRS.Queries;
using Domain.Event.Dto;
using MediatR;

namespace Application.Event.Queries;

public class EventQueries
{
    public record GetEventByIdQuery(Guid EventId) : IQuery<EventDto?>;
    public record GetAllEventsQuery() : IQuery<List<EventDto>>;
    
    public record GetActiveEventsQuery(Guid UserId) : IQuery<List<EventDto>>;
    public record GetEventDetailsQuery(Guid EventId, Guid UserId) : IQuery<EventDto>;


}