using Domain.Event;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class EventParticipationConfiguration : IEntityTypeConfiguration<EventParticipation>
{
    public void Configure(EntityTypeBuilder<EventParticipation> builder)
    {
        builder
            .HasKey(ep => ep.ParticipationId);

        builder
            .Property(ep => ep.Status).HasMaxLength(50).HasDefaultValue("pending");

        builder
            .Property(ep => ep.CreatedAt).IsRequired();

        builder
            .Property(ep => ep.CompletedAt).IsRequired(false);

        builder
            .HasOne(ep => ep.User)
            .WithMany()
            .HasForeignKey(ep => ep.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ep => ep.Scenario)
            .WithMany()
            .HasForeignKey(ep => ep.ScenarioId);

        builder.HasOne<Event>()
            .WithMany()
            .HasForeignKey(p => p.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}