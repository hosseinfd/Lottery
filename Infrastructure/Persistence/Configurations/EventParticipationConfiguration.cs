using Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EventParticipationConfiguration : IEntityTypeConfiguration<EventParticipantsDao>
{
    public void Configure(EntityTypeBuilder<EventParticipantsDao> builder)
    {
        builder
            .HasKey(ep => ep.ParticipantId);

        builder
            .Property(ep => ep.Status).HasMaxLength(50).HasDefaultValue("pending");

        builder
            .Property(ep => ep.CreatedAt).IsRequired();

        builder
            .Property(ep => ep.CompletedAt).IsRequired(false);

        builder
            .HasOne(ep => ep.UserDao)
            .WithMany()
            .HasForeignKey(ep => ep.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ep => ep.ScenarioDao)
            .WithMany()
            .HasForeignKey(ep => ep.ScenarioId);

        builder.HasOne<EventDao>()
            .WithMany()
            .HasForeignKey(p => p.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}