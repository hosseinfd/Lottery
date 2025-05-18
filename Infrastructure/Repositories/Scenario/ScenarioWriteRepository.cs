using Domain.RepoInterfaces.Scenario;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Scenario;

public class ScenarioWriteRepository : WriteRepository<Domain.Entities.Event.Scenario>,IScenarioWriteRepository
{
    public ScenarioWriteRepository(AppDbContext context) : base(context)
    {
    }
}