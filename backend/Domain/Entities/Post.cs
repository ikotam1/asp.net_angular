using Domain.Entities.Common;

namespace Domain.Entities;

public partial class Post : TrackingEntity
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }
}

public partial class Post
{
    // Null when lazy loading
    public User? Author { get; set; }
}
