using Domain.Entities.Winner;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class WinnerConfiguration : IEntityTypeConfiguration<Winner>
{
    public void Configure(EntityTypeBuilder<Winner> builder)
    {
        builder.HasKey(w => w.WinnerId);
        builder.Property(w => w.RewardValue).HasColumnType("DECIMAL");
        builder.HasOne(w => w.Scenario).WithMany().HasForeignKey(w => w.ScenarioId);
        builder.HasOne(w => w.User).WithMany().HasForeignKey(w => w.UserId);
        builder.HasOne(w => w.Currency).WithMany().HasForeignKey(w => w.CurrencyId);
        
        builder.ApplyCommonConfigurations();
    }
}