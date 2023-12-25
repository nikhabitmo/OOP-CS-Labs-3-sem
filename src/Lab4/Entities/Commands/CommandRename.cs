using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandRename : ICommand
{
    public CommandRename(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; private set; }
    public string Name { get; private set; }

    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState != null) return fileSystemState.RenameFile(Path, Name);

        return new CommandResultError { Message = "Something went wrong" };
    }
}