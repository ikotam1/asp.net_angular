using System;

namespace Domain.Entities.common;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
}
