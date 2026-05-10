using System;

namespace Application.DTOs.Post;

public class GetPostDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string AuthorName { get; set; } = string.Empty;
}
