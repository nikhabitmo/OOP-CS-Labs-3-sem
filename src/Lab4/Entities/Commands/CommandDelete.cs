using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandDelete : ICommand
{
    public CommandDelete(string path)
    {
        Path = path;
    }

    public string Path { get; private set; }

    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState != null) return fileSystemState.DeleteFile(Path);

        return new CommandResultError { Message = "Something went wrong" };
    }
}