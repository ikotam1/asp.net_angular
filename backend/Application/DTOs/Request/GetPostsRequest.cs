using System;

namespace Application.DTOs.Request;

public class GetPostsRequest
{
    public Guid AuthorId { get; set; }
}
