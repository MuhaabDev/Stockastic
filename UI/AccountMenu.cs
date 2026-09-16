using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services.Authentication;
namespace Stockastic.UI;
public class AccountMenu(AuthService authService)
{
    public async Task<User?> Show()
    {
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
        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        return await authService.Login(username!, password!);
    }

    private async Task Register()
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        await authService.Register(username!, email!, password!);
    }
}
