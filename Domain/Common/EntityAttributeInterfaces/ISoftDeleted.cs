namespace Domain.Common.EntityAttributeInterfaces;

public interface ISoftDeleted
{
    bool IsActive { get; set; }
    DateTime? DeactivatedAt { get; set; }
}