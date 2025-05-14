using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static void ApplyCommonConfigurations<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property(nameof(User.CreatedAt))
            // .HasDefaultValueSql("getdate()");
            .HasDefaultValue(DateTime.UtcNow);

        // Common configurations can go here (e.g., Timestamp handling, Soft Deletes, etc.)
    }
}