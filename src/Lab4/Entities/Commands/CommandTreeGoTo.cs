using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandTreeGoTo : ICommand
{
    public CommandTreeGoTo(string workingDirectory)
    {
        WorkingDirectory = workingDirectory;
    }

    public string? WorkingDirectory { get; private set; } = string.Empty;

    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (WorkingDirectory != null)
        {
            fileSystemState?.TreeGoTo(WorkingDirectory);
        }

        return new CommandResultError { Message = "Input working directory is null" };
    }
}