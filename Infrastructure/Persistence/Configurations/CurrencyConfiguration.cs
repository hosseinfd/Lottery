using Domain.Entities.Currency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<CurrencyDao>
{
    public void Configure(EntityTypeBuilder<CurrencyDao> builder)
    {
        builder.HasKey(c => c.CurrencyId);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(255);

        builder.Property(c => c.Symbol).IsRequired().HasMaxLength(10);

        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasIndex(c => c.Symbol).IsUnique();
    }
}