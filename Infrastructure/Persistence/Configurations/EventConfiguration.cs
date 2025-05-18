using Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<EventDao>
{
    public void Configure(EntityTypeBuilder<EventDao> builder)
    {
        builder.HasKey(e => e.EventId);
        builder.Property(e => e.Type).HasMaxLength(100);
        builder.Property(e => e.Title).HasMaxLength(255);
        builder.Property(e => e.Description).HasColumnType("TEXT");
        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.EndDate).IsRequired();
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.EventRules).HasColumnType("JSON");
    }
}