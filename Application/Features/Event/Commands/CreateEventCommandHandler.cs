using Application.BuildingBlocks.CQRS.Commands;
using Domain.Entities.Event;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Event;

namespace Application.Features.Event.Commands;

public class CreateEventCommandHandler : ICommandHandler<EventCommands.CreateEventCommand, Guid>
{
    private readonly IEventWriteRepository _eventWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(IEventWriteRepository eventWriteRepository, IUnitOfWork unitOfWork)
    {
        _eventWriteRepository = eventWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(EventCommands.CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = new EventDao
        {
            Id = Guid.NewGuid(),
            Type = request.Type,
            Title = request.Title,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsActive = request.IsActive,
            EventRules = request.EventRules
        };

        _eventWriteRepository.Add(@event);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }
}