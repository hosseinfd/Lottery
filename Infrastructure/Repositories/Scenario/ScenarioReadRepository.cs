using AutoMapper;
using Domain.Entities.Event;
using Domain.RepoInterfaces.Scenario;

namespace Infrastructure.Repositories.Scenario;

public class ScenarioReadRepository(AppDbContext context) : ReadRepository<ScenarioDao>(context), IScenarioReadRepository;