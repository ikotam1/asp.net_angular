using Application.DTOs.Post;
using Application.Interfaces.common;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPostRepository : ICommonRepository<Post>
{
    Task<List<GetPostDto>?> GetPostsByAuthorId(Guid authorId);

    Task CreatePost(CreatePostDto dto);
}
