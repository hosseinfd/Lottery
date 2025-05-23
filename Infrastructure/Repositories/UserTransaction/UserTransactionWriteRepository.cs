﻿using Domain.RepoInterfaces.UserTransaction;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserTransaction;

public class UserTransactionWriteRepository : WriteRepository<Domain.Entities.UserTransaction.UserTransactionDao>,
    IUserTransactionWriteRepository
{
    private readonly AppDbContext _context;

    public UserTransactionWriteRepository(AppDbContext context) : base(context) => _context = context;
    
    public async Task<bool> HasRewardForScenarioAsync(Guid userId, Guid scenarioId, CancellationToken ct = default)
    {
        return await _context.UserTransactions
            .AnyAsync(t => 
                t.UserId == userId && 
                t.ScenarioId == scenarioId && 
                t.Amount > 0, // Positive amount indicates reward
            ct);
    }
}