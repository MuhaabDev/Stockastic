using Stockastic.Domain.Entities;
using Stockastic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.UI;
public class Settings(SettingsService settings)
{
    public async Task show(User user)
    {
        Console.WriteLine("[1] Change Color\t\t[2] Return");

        string input = Console.ReadLine() ?? string.Empty;

        if (input == "1")
        {
            string color = ChooseColor();
            await settings.ChangeColor(user, color);
        }
    }

    public string ChooseColor()
    {
        foreach (string color in Enum.GetNames(typeof(ConsoleColor)))
        {
            ConsoleColor currentColor =
                Enum.Parse<ConsoleColor>(color);

            if (currentColor != ConsoleColor.Black)
            {
                Console.ForegroundColor = currentColor;
                Console.Write($"{color,-30}");
            }
            else
            {
                Console.Write($"{color,-30}");
            }

            if ((int)currentColor % 4 == 3)
                Console.WriteLine();
        }

        Console.ResetColor();

        Console.WriteLine();
        Console.Write("Please write color name: ");

        while (true)
        {
            string colorName =
                Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(colorName))
            {
                Console.Write("Wrong Input. Try Again: ");
                continue;
            }

            return colorName;
        }
    }
}   