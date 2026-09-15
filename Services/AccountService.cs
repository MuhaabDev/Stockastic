using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Services
{
    public class AccountService
    {
        List<User> user;
        DataService dataService = new DataService();
        public AccountService(List<User> users)
        {
            user = users;
        }

        public bool checkAccount(string username, string password)
        {
            bool accountFound = false;
            for (int i = 0; i < user.Count(); i++)
            {
                if (username == user[i].username && password == user[i].password)
                {
                    accountFound = true;
                    Accounts.currentAccount = i;
                    break;
                }
            }
            return accountFound;
        }

        public void RegisterAccount(string username, string password)
        {
            if (checkUsername(username) && CheckPassword(password))
            {
                User newUser = new User();
                newUser.username = username;
                newUser.password = password;
                user.Add(newUser);
                dataService.SaveUsers(user);
                Console.WriteLine("Account Created Successfully");
            }
        }

        public bool checkUsername(string username)
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
                for (int i = 0; i < user.Count(); i++)
                {
                    if (username.Equals(user[i].username, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Username already Exists , Choose another Name");
                        exist = true;
                        break;
                    }
                }
            }
            if (exist)
            {
                return false;
            }
            return true;
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

        public void LogIn()
        {
            string userName, password;
            Console.Write("Username: ");
            userName = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();

            if (checkAccount(userName, password))
            {
                Console.WriteLine("Login Succesfully");
                Accounts.loggedIn = true;
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
        }

        public void Register()
        {
            string userName, password;
            Console.WriteLine("Enter Your Username : ");
            userName = Console.ReadLine();
            Console.WriteLine("Enter Your Password : ");
            password = Console.ReadLine();
            RegisterAccount(userName, password);
        }

        public static void CloseProgram()
        {
            Accounts.running = false;
        }

    }
}
