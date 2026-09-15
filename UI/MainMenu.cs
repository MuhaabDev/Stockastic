using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI
{
    public class MainMenu
    {
        public void StartProgram()
        {
            displayHeader();

            AccountMenu accountMenu;
            UserMenu userMenu;

            while (Accounts.running)
            {
                if (Accounts.loggedIn) //Show User Menu
                {
                    userMenu = new UserMenu(users, dataService);
                    userMenu.Show();
                }
                else // Register/Login
                {
                    accountMenu = new AccountMenu(users);
                    accountMenu.Show();
                }
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
}
