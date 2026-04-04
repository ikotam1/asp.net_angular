using System;
using Domain.Enums;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // TODO: check nullable
    public string PasswordHashed { get; set; }

    // TODO: Scaling by policies and permissions
    public EUserRole Role { get; set; } = EUserRole.User;
}
