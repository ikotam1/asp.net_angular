using Application.DTOs.Post;
using Application.DTOs.Request;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentResults;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;

    public PostService(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<GetPostDto>>> GetAllPosts(Guid authorId)
    {
        var posts = await _repository.GetPostsByAuthorId(authorId);

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
