using System.Reflection;
using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;
using Domain.Entities.UserBalance;
using Domain.Entities.UserTransaction;
using Domain.Entities.Winner;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<UserBalance> UserBalances { get; set; }
    public DbSet<UserTransaction> UserTransactions { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Scenario> Scenarios { get; set; }
    public DbSet<EventParticipation> EventParticipations { get; set; }
    public DbSet<Winner> Winners { get; set; }
    // public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}