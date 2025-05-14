using Domain.UserBalance;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalance>
{
    public void Configure(EntityTypeBuilder<UserBalance> builder)
    {
        builder.HasKey(ub => ub.BalanceId);
        builder.Property(ub => ub.Balance).HasDefaultValue(0);
        builder.HasOne(ub => ub.User).WithMany().HasForeignKey(ub => ub.UserId);
        builder.HasOne(ub => ub.Currency).WithMany().HasForeignKey(ub => ub.CurrencyId);
        
        builder.ApplyCommonConfigurations();
    }
}