using System.ComponentModel.DataAnnotations;
using Domain.Entities.common;
using Domain.Enums;

namespace Domain.Entities;

public partial class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // Not nullable, set in Fluent API configuration
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string PasswordHashed { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    // TODO: Scaling by policies and permissions
    public EUserRole Role { get; set; } = EUserRole.User;
}

public partial class User
{
    public List<Post>? Posts { get; set; }
}
