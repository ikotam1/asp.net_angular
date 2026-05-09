using System;

namespace Domain.Entities.Common;

public abstract class TrackingEntity : BaseEntity
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; private set; }

    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
