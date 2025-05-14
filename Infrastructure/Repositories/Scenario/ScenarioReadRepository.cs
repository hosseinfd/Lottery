using AutoMapper;
using Domain.RepoInterfaces.Scenario;

namespace Infrastructure.Repositories.Scenario;

public class ScenarioReadRepository : ReadRepository<Domain.Event.Scenario>, IScenarioReadRepository
{
    public ScenarioReadRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}