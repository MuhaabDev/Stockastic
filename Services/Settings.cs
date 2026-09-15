using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stockastic.Services
{
    public class Settings
    {
        //User user = new User();
        //public Settings(User users)
        //{
        //    user = users;
        //}

        //private ConsoleColor currentColor = ConsoleColor.White;
        //public void DisplaySettings()
        //{
        //    Console.WriteLine("[1] Change Color \t \t [2] Return");
        //    string input = Console.ReadLine() ?? string.Empty;
        //    if (input == "1")
        //    {
        //        changeColor(ChooseColor());
        //    }
        //}

        //public string ChooseColor()
        //{
        //    foreach (string color in Enum.GetNames(typeof(ConsoleColor)))
        //    {
        //        ConsoleColor currentColor = Enum.Parse<ConsoleColor>(color);
        //        if (currentColor != ConsoleColor.Black)
        //        {
        //            Console.ForegroundColor = currentColor;
        //            Console.Write($"{color,-30}");
        //        }
        //        else
        //        {
        //            Console.Write($"{color,-30}");
        //        }
        //        if ((int)currentColor % 4 == 3)
        //            Console.WriteLine();
        //    }

        //    Console.ResetColor();
        //    Console.WriteLine();
        //    Console.Write("Please write color name: ");
        //    while (true)
        //    {
        //        string colorName = Console.ReadLine() ?? string.Empty;
        //        if (colorName == string.Empty)
        //        {
        //            Console.Write("Wrong Input Try Again : ");
        //        }
        //        else
        //        {
        //            return colorName;
        //        }
        //    }
        //}

        ////public void changeColor(string colorName)
        ////{
        ////    try
        ////    {
        ////        ConsoleColor SelectedColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName, true);
        ////        Console.ForegroundColor = SelectedColor;
        ////        user.SelectedColor = SelectedColor;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Console.WriteLine($"Wrong Input !!! : {ex.Message}");
        ////    }
        ////}
    }
}