using Application.Common.Errors;
using Application.Common.Extensions;
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
        posts = posts.Select(p => new GetPostDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = (p.Content.Length <= 50) ? p.Content : p.Content.Substring(0, 50) + "...",
            AuthorName = p.AuthorName
        }).ToList();

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

    public async Task<Result<GetPostDto>> GetPostById(Guid authorId, Guid postId)
    {
        var post = await _repository.GetByIdAsync(postId);
        if (post == null || post.AuthorId != authorId)
            return Result.Fail(PostErrors.PostNotFound.ToError());

        var postDto = new GetPostDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            AuthorName = string.Empty
        };

        return Result.Ok(postDto);
    }
}
