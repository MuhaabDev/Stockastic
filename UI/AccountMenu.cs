using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.UI
{
    public class AccountMenu
    {
        AccountService AccountService { get; set; }
        public AccountMenu(List<User> users)
        {
            AccountService = new AccountService(users);
        }
        public void Show()
        {
            Console.WriteLine("1: Login \t\t 2: Register \t\t 3 : Exit");
            var isSuccesfull = int.TryParse(Console.ReadLine(), out int op);
            switch (op)
            {
                case 1:
                    AccountService.LogIn();
                    break;
                case 2:
                    AccountService.Register();
                    break;
                case 3:
                    AccountService.CloseProgram();
                    break;
                default:
                    Console.WriteLine("Wrong input, Try Again !");
                    break;
            }
        }
    }
}
