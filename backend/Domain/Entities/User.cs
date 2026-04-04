using System;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
