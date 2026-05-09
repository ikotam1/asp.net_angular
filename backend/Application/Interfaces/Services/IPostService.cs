using Application.DTOs.Post;
using Application.DTOs.Request;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IPostService
{
    Task<Result<List<GetPostDto>>> GetAllPosts(GetPostsRequest request);

    Task<Result> CreatePost(CreatePostRequest request);
}
