using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Authentication;
public sealed class LoginUser(IUserRepository userRepository, IPasswordHasher PasswordHasher)
{
    public async Task<User> Handle(string idetifier , string password)
    {
        User? user = await userRepository.GetByUsernameOrEmail(idetifier);
        if (user is null)
            throw new Exception("The user was not found");
        
        bool verified = PasswordHasher.verify(password, user.PasswordHash);
        if (!verified) throw new Exception("The password is incorrect");
        return user;
    }
}
