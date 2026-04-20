using Application.DTOs.Post;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PostRepository : CommonRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<GetPostDto>?> GetPostsByAuthorId(Guid authorId)
    {
        return await _context.Posts
            .Where(p => p.AuthorId == authorId)
            .Include(p => p.Author)
            .Select(p => new GetPostDto
            {
                Title = p.Title,
                Content = p.Content,
                AuthorName = p.Author!.Name
            })
            .ToListAsync();
    }

    public async Task CreatePost(CreatePostDto dto)
    {
        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            AuthorId = dto.AuthorId
        };

        await _context.AddAsync(post);
    }
}
