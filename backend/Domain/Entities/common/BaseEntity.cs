using System;

namespace Domain.Entities.Common;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
}
