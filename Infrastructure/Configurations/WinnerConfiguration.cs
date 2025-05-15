using Domain.Entities.Winner;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class WinnerConfiguration : IEntityTypeConfiguration<WinnerDao>
{
    public void Configure(EntityTypeBuilder<WinnerDao> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.RewardValue).HasColumnType("DECIMAL");
        builder.HasOne(w => w.ScenarioDao).WithMany().HasForeignKey(w => w.ScenarioId);
        builder.HasOne(w => w.UserDao).WithMany().HasForeignKey(w => w.UserId);
        builder.HasOne(w => w.CurrencyDao).WithMany().HasForeignKey(w => w.CurrencyId);
        
        builder.ApplyCommonConfigurations();
    }
}