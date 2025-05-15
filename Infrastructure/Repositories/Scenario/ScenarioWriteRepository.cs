using Domain.Entities.Event;
using Domain.RepoInterfaces.Scenario;

namespace Infrastructure.Repositories.Scenario;

public class ScenarioWriteRepository : WriteRepository<ScenarioDao>,IScenarioWriteRepository
{
    public ScenarioWriteRepository(AppDbContext context) : base(context)
    {
    }
}