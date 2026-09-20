using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.UI;
public class MainMenu(AccountMenu accountMenu , UserMenu userMenu)
{
    public async Task Show()
    {
        ApplyDefaultSettings();
        displayHeader();
        while (true)
        {
            User? currentUser = await accountMenu.Show();
            if (currentUser is null)
            {
                Console.WriteLine("User Doesnt Exist");
                continue;
            }
            await userMenu.Show(currentUser);
        }
    }

    public void displayHeader()
    {
        Console.Title = "Stock Portfolio Tracker";
        Console.WriteLine("==========================================================");
        Console.WriteLine("               WELCOME TOOOO STOCKASTIC");
        Console.WriteLine("==========================================================");
    }

    private void ApplyDefaultSettings()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}
