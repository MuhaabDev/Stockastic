using Microsoft.EntityFrameworkCore;
using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Authentication;
public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<bool> Exists(string email)
    {
        return await context.Users.AnyAsync(u => u.Email == email);
    }
    public async Task<User?> GetByEmail(string email)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
    public async Task<User?> GetByUsernameOrEmail(string identifier)
    {
        return await context.Users.SingleOrDefaultAsync(u =>u.Email == identifier || u.Username == identifier);
    }

    public async Task Insert(User user)
    {
        user.Portfolio = new Portfolio();
        user.Watchlist = new Watchlist();
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }
}