using Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ScenarioConfiguration : IEntityTypeConfiguration<ScenarioDao>
{
    public void Configure(EntityTypeBuilder<ScenarioDao> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Condition).HasColumnType("JSON");
        builder.Property(s => s.RewardType).HasMaxLength(100);
        builder.Property(s => s.RewardValue).HasColumnType("DECIMAL");
        builder.Property(s => s.AdditionalData).HasColumnType("JSON");
        builder.HasOne(s => s.EventDao).WithMany().HasForeignKey(s => s.EventId);
    }
}