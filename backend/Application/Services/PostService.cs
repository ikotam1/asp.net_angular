using Application.Common.Errors;
using Application.Common.Extensions;
using Application.DTOs.Post;
using Application.DTOs.Request;
using Application.Interfaces;
using Domain.Entities;
using FluentResults;

namespace Application.Services;

public class PostService
{
    private readonly IPostRepository _repository;

    private readonly IUserRepository _userRepository;

    public PostService(IPostRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<GetPostDto>>> GetAllPosts(GetPostsRequest request)
    {
        var posts = await _repository.GetPostsByAuthorId(request.AuthorId);

        return Result.Ok(posts);
    }

    public async Task<Result> CreatePost(CreatePostRequest request)
    {
        var post = new Post
        {
            Title = request.Title,
            Content = request.Content,
            AuthorId = request.AuthorId
        };

        await _repository.AddAsync(post);

        return Result.Ok();
    }
}
