using Domain.Entities.UserBalance;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalanceDao>
{
    public void Configure(EntityTypeBuilder<UserBalanceDao> builder)
    {
        builder.HasKey(ub => ub.Id);
        builder.Property(ub => ub.Balance).HasDefaultValue(0);
        builder.HasOne(ub => ub.UserDao).WithMany().HasForeignKey(ub => ub.UserId);
        builder.HasOne(ub => ub.CurrencyDao).WithMany().HasForeignKey(ub => ub.CurrencyId);
        
        builder.ApplyCommonConfigurations();
    }
}