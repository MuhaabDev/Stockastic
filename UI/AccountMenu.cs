using Stockastic.Data;
using Stockastic.Domain.Entities;
using Stockastic.Services;
namespace Stockastic.UI;
public class AccountMenu(AuthService authService)
{
    public User? Show()
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
                return Login();
            case 2:
                Register();
                return null;
            default:
                Console.WriteLine("Invalid option.");
                return null;
        }
    }

    private User? Login()
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        return authService.Login(username!, password!);
    }

    private void Register()
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        authService.Register(username!, email!, password!);
    }
}
