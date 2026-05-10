using System.Text.Json.Serialization;

namespace Application.DTOs.Request;

public class CreatePostRequest
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid AuthorId { get; set; }
}
