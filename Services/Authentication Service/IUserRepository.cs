using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Authentication;
public interface IUserRepository
{
    Task<bool> Exists(string email);
    Task<User?> GetByEmail(string email);
    Task<User?> GetByUsernameOrEmail(string identifier);
    Task Insert(User user);
}