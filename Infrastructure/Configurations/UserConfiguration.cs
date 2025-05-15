using Domain.Entities.User;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserDao>
{
    public void Configure(EntityTypeBuilder<UserDao> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.TelegramId).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Username).HasMaxLength(255);
        builder.Property(u => u.Name).HasMaxLength(255);
        builder.HasIndex(u => u.TelegramId).IsUnique().HasDatabaseName("idx_users_telegram_id");
        
        builder.ApplyCommonConfigurations();
    }
}