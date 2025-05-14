using Domain.Currency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(c => c.CurrencyId);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(255);

        builder.Property(c => c.Symbol).IsRequired().HasMaxLength(10);

        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasIndex(c => c.Symbol).IsUnique();
    }
}