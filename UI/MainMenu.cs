using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.UI;
public class MainMenu(AccountMenu accountMenu , UserMenu userMenu)
{
    public void Show()
    {
        displayHeader();
        while (true)
        {
            var currentUser = accountMenu.Show();
            if (currentUser is null) continue;
            userMenu.Show(currentUser);
        }
    }

    public void displayHeader()
    {
        Console.Title = "Stock Portfolio Tracker";
        Console.WriteLine("==========================================================");
        Console.WriteLine("               Welcome To Stock Portfolio Tracker");
        Console.WriteLine("==========================================================");
    }
}
