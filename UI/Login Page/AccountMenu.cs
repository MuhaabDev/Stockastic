using NetTopologySuite.Densify;
using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services.Authentication;
namespace Stockastic.UI;
public class AccountMenu(AuthService authService)
{
    public async Task<User?> Show()
    {
        ApplyDefaultSettings();
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.Write("Choose: ");

        if(!int.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Invalid Input");
            return null;
        }

        switch (option) {
            case 1: 
                return await Login();
            case 2:
                await Register();
                return null;
            default:
                Console.WriteLine("Invalid option.");
                return null;
        }
    }

    private async Task<User?> Login()
    {
        Console.Write("Username or Email: ");
        string? identifier = Console.ReadLine();

        Console.Write("Password: ");
        string? password = Console.ReadLine();


        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Username/email and password are required.");
            return null;
        }

        return await authService.Login(identifier, password);
    }

    private async Task Register()
    {
        Console.Write("Username: ");
        string? username = Console.ReadLine();

        Console.Write("Email: ");
        string? email = Console.ReadLine();

        Console.Write("Password: ");
        string? password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("All fields are required.");
            return;
        }

        bool completed = await authService.Register(username, email, password);
        Console.WriteLine( completed ? "Account Registered Successfully" : "Account Already Exists");
    }

    private void ApplyDefaultSettings()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}