using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Application.Interfaces.Response;
using Domain.Entities;

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

    public async Task<IResult> GetAllPosts(GetPostsRequest request)
    {
        var posts = await _repository.GetPostsByAuthorId(request.AuthorId);

        return ResultCreator.Success(posts);
    }

    public async Task<IResult> CreatePost(CreatePostRequest request)
    {
        try
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                AuthorId = request.AuthorId
            };

            await _repository.AddAsync(post);

            return ResultCreator.Success(post.Id);
        }
        catch (Exception ex)
        {
            return ResultCreator.Failure(ex.Message);
        }
    }
}
