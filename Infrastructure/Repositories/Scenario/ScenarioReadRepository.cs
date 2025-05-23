﻿using AutoMapper;
using Domain.RepoInterfaces.Scenario;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Scenario;

public class ScenarioReadRepository : ReadRepository<Domain.Entities.Event.ScenarioDao>, IScenarioReadRepository
{
    public ScenarioReadRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}