using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Authentication;
public interface IUserRepository
{
    Task<bool> Exists(string email);
    Task Insert(User user);
    Task<User?> GetByEmail(string email);
}