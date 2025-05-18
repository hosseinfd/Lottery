using Application.BuildingBlocks.CQRS.Commands;
using Domain.Common;
using Domain.Exceptions;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Event;

namespace Application.Features.Event.Commands;

public class CompleteParticipationCommandHandler : ICommandHandler<EventCommands.CompleteParticipationCommand>
{
    private readonly IParticipationCommandRepository _participationCommandRepo;
    private readonly IEventWriteRepository _eventReadRepo;
    private readonly IUnitOfWork _unitOfWork;
    public CompleteParticipationCommandHandler(
        IParticipationCommandRepository participationCommandRepo,
        IEventWriteRepository eventReadRepo, IUnitOfWork unitOfWork)
    {
        _participationCommandRepo = participationCommandRepo;
        _eventReadRepo = eventReadRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(EventCommands.CompleteParticipationCommand request, CancellationToken ct)
    {
        // Validate event exists
        var eventExists = await _eventReadRepo.ExistsAsync(request.EventId, ct);
        if (!eventExists)
            throw new NotFoundException(new ValidationItem(null,"Event not found",null));

        // Get participation
        var participation = await _participationCommandRepo.GetAsync(request.UserId, request.EventId, ct)
                            ?? 
                            throw new NotFoundException(new ValidationItem(null,"Participation not found",null));

        // Complete participation
        await _participationCommandRepo.CompleteParticipationAsync(participation.Id, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}