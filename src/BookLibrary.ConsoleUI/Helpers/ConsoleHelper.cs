namespace BookLibrary.ConsoleUI.Helpers;

public static class ConsoleHelper
{
    public static void WriteLineWithColor(string message, ConsoleColor color)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    public static void WriteSuccess(string message)
    {
        WriteLineWithColor(message, ConsoleColor.Green);
    }

    public static void WriteError(string message)
    {
        WriteLineWithColor(message, ConsoleColor.Red);
    }

    public static void WriteWarning(string message)
    {
        WriteLineWithColor(message, ConsoleColor.Yellow);
    }

    public static void WriteHeader(string header)
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine(header.PadLeft(25 + header.Length / 2));
        Console.WriteLine(new string('=', 50));
    }

    public static string ReadInput(string prompt)
    {
        Console.Write($"{prompt}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static int ReadInteger(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        while (true)
        {
            var input = ReadInput(prompt);
            if (int.TryParse(input, out int result) && result >= minValue && result <= maxValue)
            {
                return result;
            }
            WriteError($"Please enter a valid number between {minValue} and {maxValue}");
        }
    }
}
