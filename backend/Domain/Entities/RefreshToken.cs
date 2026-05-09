using Domain.Entities.Common;

namespace Domain.Entities;

public partial class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime CreatedAt { get; set; }
}

public partial class RefreshToken
{
    public User? User { get; set; }
}
