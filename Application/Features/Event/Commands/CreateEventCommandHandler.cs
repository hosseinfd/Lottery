using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Event;

namespace Application.Features.Event.Commands;

public class CreateEventCommandHandler: ICommandHandler<EventCommands.CreateEventCommand, Guid>
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
        var @event = new Domain.Entities.Event.Event
        {
            EventId = Guid.NewGuid(),
            Type = request.Type,
            Title = request.Title,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsActive = request.IsActive,
            EventRules = request.EventRules
        };

        await _eventWriteRepository.AddAsync(@event);
        await _unitOfWork.SaveChangesAsync();

        return @event.EventId;
    }
}