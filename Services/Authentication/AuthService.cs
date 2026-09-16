using Microsoft.VisualBasic;
using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Stockastic.Services.Authentication;
public class AuthService(ApplicationDbContext context , PasswordHasher passwordHasher , LoginUser loginUser)
{
    public void Register(string username, string email ,string password)
    {
        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = passwordHasher.Hash(password)
        };
        context.Users.Add(user);
        context.SaveChanges();
    }

    public User? Login(string username, string password)
    {
        return context.Users.FirstOrDefault(
            u => u.Username == username && u.PasswordHash == password
        );
    }

    public bool CheckPassword(string password)
    {
        if (password.Length < 8)
        {
            Console.WriteLine("Password must be at least 8 characters long.");
            return false;
        }

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        bool hasSpecial = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
                hasUpper = true;
            else if (char.IsLower(c))
                hasLower = true;
            else if (char.IsDigit(c))
                hasDigit = true;
            else if (char.IsWhiteSpace(c))
            {
                Console.WriteLine("Password cannot contain spaces.");
                return false;
            }
            else
                hasSpecial = true;
        }

        if (!hasUpper)
        {
            Console.WriteLine("Password must contain at least one uppercase letter.");
            return false;
        }

        if (!hasLower)
        {
            Console.WriteLine("Password must contain at least one lowercase letter.");
            return false;
        }

        if (!hasDigit)
        {
            Console.WriteLine("Password must contain at least one digit.");
            return false;
        }

        if (!hasSpecial)
        {
            Console.WriteLine("Password must contain at least one special character.");
            return false;
        }

        return true;
    }

    public bool CheckUsername(string username)
    {
        bool exist = false;
        if (username.Length < 3)
        {
            Console.WriteLine("Username Must be Greater than 3 Character");
            return false;
        }
        else if (username.Length > 20)
        {
            Console.WriteLine("Username Must be Less than 20 Character");
            return false;
        }
        else if (username.Contains(' '))
        {
            Console.WriteLine("Username cannot contain spaces.");
            return false;
        }
        else if (username.Any(c => !char.IsLetterOrDigit(c) && c != '_' && c != '.'))
        {
            Console.WriteLine("Username can only contain letters, numbers, '_' and '.'.");
            return false;
        }
        else
        {
            //for (int i = 0; i < user.Count(); i++)
            //{
            //    if (username.Equals(user[i].username, StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine("Username already Exists , Choose another Name");
            //        exist = true;
            //        break;
            //    }
            //}
        }
        if (exist)
        {
            return false;
        }
        return true;
    }
}