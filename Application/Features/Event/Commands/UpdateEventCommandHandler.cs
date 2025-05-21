using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using Domain.RepoInterfaces.Event;

namespace Application.Features.Event.Commands;

public class UpdateEventCommandHandler: ICommandHandler<EventCommands.UpdateEventCommand, bool>
{
    private readonly IEventWriteRepository _eventWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventCommandHandler(IEventWriteRepository eventWriteRepository, IUnitOfWork unitOfWork)
    {
        _eventWriteRepository = eventWriteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(EventCommands.UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventWriteRepository.GetByIdAsync(request.EventId);
        if (@event == null) return false;

        if (!string.IsNullOrWhiteSpace(request.Title)) @event.Title = request.Title;
        if (!string.IsNullOrWhiteSpace(request.Description)) @event.Description = request.Description;
        if (request.StartDate.HasValue) @event.StartDate = request.StartDate.Value;
        if (request.EndDate.HasValue) @event.EndDate = request.EndDate.Value;
        if (request.IsActive.HasValue) @event.IsActive = request.IsActive.Value;
        if (!string.IsNullOrWhiteSpace(request.EventRules)) @event.EventRules = request.EventRules;

        // await _eventWriteRepository.UpdateAsync(@event);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
