using System.Reflection;
using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;
using Domain.Entities.UserBalance;
using Domain.Entities.UserTransaction;
using Domain.Entities.Winner;

namespace Infrastructure;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserDao> Users { get; set; }
    public DbSet<CurrencyDao> Currencies { get; set; }
    public DbSet<UserBalanceDao> UserBalances { get; set; }
    public DbSet<TransactionDao> UserTransactions { get; set; }
    public DbSet<EventDao> Events { get; set; }
    public DbSet<ScenarioDao> Scenarios { get; set; }
    public DbSet<EventParticipationDao> EventParticipations { get; set; }
    public DbSet<WinnerDao> Winners { get; set; }
    // public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}