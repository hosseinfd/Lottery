using Domain.RepoInterfaces.Scenario;

namespace Infrastructure.Repositories.Scenario;

public class ScenarioWriteRepository : WriteRepository<Domain.Event.Scenario>,IScenarioWriteRepository
{
    public ScenarioWriteRepository(AppDbContext context) : base(context)
    {
    }
}