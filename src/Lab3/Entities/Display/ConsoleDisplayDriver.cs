using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void Clear()
    {
        Console.Clear();
    }

    public void SetTextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}