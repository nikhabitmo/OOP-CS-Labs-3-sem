using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class FileOutputWriter : IDisplayDriver
{
    private string _filePath;

    public FileOutputWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void SetTextColor(ConsoleColor color)
    { // useless)
    }

    public void WriteText(string text)
    {
        File.WriteAllText(_filePath, text);
    }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }
}