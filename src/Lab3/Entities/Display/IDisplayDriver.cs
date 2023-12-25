using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplayDriver
{
    void Clear();
    void SetTextColor(ConsoleColor color);
    void WriteText(string text);
}