using Application.BuildingBlocks.CQRS.Commands;
using Domain.Event.Dto;

namespace Application.Event.Commands;

public class EventCommands
{
    public record CreateEventCommand(string Type, string Title, string Description, DateTime StartDate, DateTime EndDate, bool IsActive, string EventRules) : ICommand<Guid>;
    public record UpdateEventCommand(Guid EventId, string? Title, string? Description, DateTime? StartDate, DateTime? EndDate, bool? IsActive, string? EventRules) : ICommand<bool>;
    public record DeleteEventCommand(Guid EventId) : ICommand<bool>;
    public record JoinEventCommand(Guid UserId, Guid EventId) : ICommand;
    
    public record CompleteParticipationCommand(Guid UserId, Guid EventId) : ICommand;



}