using Application.DTOs.Post;
using Application.DTOs.Request;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IPostService
{
    Task<Result<GetPostDto>> GetPostById(Guid authorId, Guid postId);
    Task<Result<List<GetPostDto>>> GetAllPosts(Guid authorId);

    Task<Result> CreatePost(CreatePostRequest request);
}
