// using Domain.Entities;
//
// namespace Infrastructure.Configurations;
//
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
// {
//     public void Configure(EntityTypeBuilder<AuditLog> builder)
//     {
//         builder.HasKey(al => al.LogId);
//         builder.Property(al => al.ActionType).HasMaxLength(100);
//         builder.Property(al => al.Timestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");
//         builder.HasOne(al => al.UserId).WithMany().HasForeignKey(al => al.UserId);
//         builder.HasOne(al => al.Scenario).WithMany().HasForeignKey(al => al.ScenarioId);
//     }
// }
