using Application.DTOs.Post;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPostRepository : ICommonRepository<Post>
{
    Task<List<GetPostDto>> GetPostsByAuthorId(Guid authorId, bool asNoTracking = true);

    Task CreatePost(CreatePostDto dto);
}
