using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class ConsoleDisplay : Display
{
    public ConsoleDisplay(IDisplayDriver driver)
        : base(driver)
    {
    }

    public override void ShowMessage(string message, ConsoleColor textColor)
    {
        DisplayDriver.Clear();
        DisplayDriver.SetTextColor(textColor);
        DisplayDriver.WriteText(message);
    }
}