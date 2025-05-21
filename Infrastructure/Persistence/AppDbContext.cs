using System.Reflection;
using Domain.Entities.Currency;
using Domain.Entities.Event;
using Domain.Entities.User;
using Domain.Entities.UserBalance;
using Domain.Entities.UserTransaction;
using Domain.Entities.Winner;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options, DateTimeProvider dateTimeProvider)
    : DbContext(options)
{
    public DbSet<UserDao> Users { get; set; }
    public DbSet<CurrencyDao> Currencies { get; set; }
    public DbSet<UserBalanceDao> UserBalances { get; set; }
    public DbSet<UserTransactionDao> UserTransactions { get; set; }
    public DbSet<EventDao> Events { get; set; }
    public DbSet<ScenarioDao> Scenarios { get; set; }
    public DbSet<EventParticipantsDao> EventParticipants { get; set; }
    public DbSet<WinnerDao> Winners { get; set; }
    // public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.AddInterceptors(new EntityCommonAttributesInterceptor(dateTimeProvider));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}