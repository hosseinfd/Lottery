using Domain.Entities.UserTransaction;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserTransactionConfiguration : IEntityTypeConfiguration<UserTransactionDao>
{
    public void Configure(EntityTypeBuilder<UserTransactionDao> builder)
    {
        builder
            .HasKey(ut => ut.TransactionId);
        
        builder
            .Property(ut => ut.Amount)
            .IsRequired();
        
        builder
            .Property(ut => ut.TransactionType)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .HasOne(ut => ut.UserDao)
            .WithMany()
            .HasForeignKey(ut => ut.UserId);
        
        builder
            .HasOne(ut => ut.CurrencyDao)
            .WithMany()
            .HasForeignKey(ut => ut.CurrencyId);

        builder.HasOne(ut => ut.EventDao)
            .WithMany(e => e.UserTransactions)
            .HasForeignKey(ut => ut.EventId);
            
        builder.HasOne(t => t.Scenario)
            .WithMany()
            .HasForeignKey(t => t.ScenarioId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ApplyCommonConfigurations();
    }
}