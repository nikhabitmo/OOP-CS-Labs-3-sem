using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public abstract class Display
{
    protected Display(IDisplayDriver driver)
    {
        DisplayDriver = driver;
    }

    protected Display()
    {
    }

    protected IDisplayDriver DisplayDriver { get; set; } = new ConsoleDisplayDriver();

    public abstract void ShowMessage(string message, ConsoleColor textColor);
}