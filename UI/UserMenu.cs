using Stockastic.Domain.Entities;
using Stockastic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI
{
    public class UserMenu
    {
        DataService dataService;
        List<User> users;
        User CurrentUser;
        public UserMenu(List<User> users, DataService dataService)
        {
            this.dataService = dataService;
            this.users = users;
            CurrentUser = users[Accounts.currentAccount];
        }
        public void Show()
        {
            UserService userService = new UserService(CurrentUser);
            Console.ForegroundColor = CurrentUser.SelectedColor ?? ConsoleColor.White;
            Settings settings = new Settings(CurrentUser);

            int op1 = UserService.displayUserService();
            switch (op1)
            {
                case 1:
                    userService.displayBalance();
                    break;
                case 2:
                    userService.AddMoney();
                    dataService?.SaveUsers(users);
                    break;
                case 3:
                    TradingMenu menu = new TradingMenu();
                    menu.Show(CurrentUser);
                    dataService?.SaveUsers(users);
                    break;
                case 4:
                    settings.DisplaySettings();
                    dataService?.SaveUsers(users);
                    break;
                case 5:
                    Accounts.loggedIn = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
