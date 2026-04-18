using System;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Register(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
