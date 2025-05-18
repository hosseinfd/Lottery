using Application.BuildingBlocks.CQRS.Commands;
using Domain.Common;
using Domain.Entities.Event;
using Domain.Exceptions;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Event;
using Domain.ServiceInterfaces;

namespace Application.Features.Event.Commands;

public class JoinEventCommandHandler : ICommandHandler<EventCommands.JoinEventCommand>
{
    private readonly IEventWriteRepository _eventRepo;
    private readonly IParticipationCommandRepository  _participationRepo;
    private readonly IDateTimeProvider _dateTime;
    private readonly IUnitOfWork _unitOfWork;
    public JoinEventCommandHandler(
        IEventWriteRepository eventRepo,
        IParticipationCommandRepository  participationRepo,
        IDateTimeProvider dateTime, IUnitOfWork unitOfWork)
    {
        _eventRepo = eventRepo;
        _participationRepo = participationRepo;
        _dateTime = dateTime;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(EventCommands.JoinEventCommand request, CancellationToken ct)
    {
        // 1. Validate event exists and is active
        var eventObj = await _eventRepo.GetByIdAsync(request.EventId, ct);
        if (eventObj == null || !eventObj.IsActive)
            throw new EventException(new ValidationItem(null, "Event not found", null));

        // 2. Check event dates
        if (_dateTime.Now < eventObj.StartDate || _dateTime.Now > eventObj.EndDate)
            throw new EventException(new ValidationItem(null, "Event is not currently active", null));

        // 3. Check if already participating
        var existing = await _participationRepo.GetAsync(request.UserId, request.EventId, ct);
        if (existing != null)
            throw new EventException(new ValidationItem(null, "Already participating in this event", null));

        // 4. Create participation
        var participation = new EventParticipation(request.UserId, request.EventId, _dateTime.Now);

        await _participationRepo.AddAsync(participation, ct);
        
        await _unitOfWork.SaveChangesAsync(ct);


    }
}