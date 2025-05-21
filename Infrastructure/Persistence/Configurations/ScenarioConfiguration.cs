using Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ScenarioConfiguration : IEntityTypeConfiguration<Scenario>
{
    public void Configure(EntityTypeBuilder<Scenario> builder)
    {
        builder.HasKey(s => s.ScenarioId);
        builder.Property(s => s.Condition).HasColumnType("JSON");
        builder.Property(s => s.RewardType).HasMaxLength(100);
        builder.Property(s => s.RewardValue).HasColumnType("DECIMAL");
        builder.Property(s => s.AdditionalData).HasColumnType("JSON");
        builder.HasOne(s => s.Event).WithMany().HasForeignKey(s => s.EventId);
    }
}