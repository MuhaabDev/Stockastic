namespace Stockastic.UI;
public static class MenuInput
{
    public static int ReadOption(int min, int max)
    {
        while (true)
        {
            Console.Write("Choose: ");

            if (int.TryParse(Console.ReadLine(), out int option) && option >= min && option <= max)
                return option;
      
            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }

    public static bool ReadConfirmation(string message)
    {
        while (true)
        {
            Console.Write($"{message} Y/N: ");
            string input =Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "y")
                return true;

            if (input == "n")
                return false;

            Console.WriteLine("Please enter Y or N.");
        }
    }

    public static int? ReadPositiveInteger(string message)
    {
        Console.Write(message);

        if (!int.TryParse(Console.ReadLine(), out int value) || value <= 0)
        {
            Console.WriteLine("Invalid number.");
            return null;
        }

        return value;
    }
}