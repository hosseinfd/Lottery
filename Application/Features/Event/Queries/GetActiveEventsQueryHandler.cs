using Application.BuildingBlocks.CQRS.Queries;
using Domain.Common;
using Domain.Entities.Event.Dto;
using Domain.RepoInterfaces.Event;
using Domain.ServiceInterfaces;

namespace Application.Features.Event.Queries;

public class GetActiveEventsQueryHandler: IQueryHandler<EventQueries.GetActiveEventsQuery,List<EventDto>>
{
    private readonly IEventReadRepository _eventRepo;
    private readonly IParticipationRepository _participationRepo;
    private readonly IDateTimeProvider _dateTime;

    public GetActiveEventsQueryHandler(
        IEventReadRepository eventRepo,
        IParticipationRepository participationRepo,
        IDateTimeProvider dateTime)
    {
        _eventRepo = eventRepo;
        _participationRepo = participationRepo;
        _dateTime = dateTime;
    }

    public async Task<List<EventDto>> Handle(
        EventQueries.GetActiveEventsQuery request,
        CancellationToken ct)
    {
        var now = _dateTime.Now;
        var events = await _eventRepo.GetActiveEventsAsync(now, ct);
        var participations = await _participationRepo
            .GetUserParticipationsAsync(request.UserId, ct);

        var eventDtos = events.Select(e => new EventDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            IsParticipating = participations.Any(p => p.EventId == e.Id),
            TotalParticipants = e.Participations.Count,
            Scenarios = e.Scenarios.Select(s => new ScenarioDto
            {
                Id = s.Id,
                Name = s.Name,
                RewardValue = s.RewardValue,
                RewardCurrencySymbol = s.RewardCurrency.Symbol
            }).ToList()
        }).ToList();

        return Result.Success(eventDtos);
    }
}