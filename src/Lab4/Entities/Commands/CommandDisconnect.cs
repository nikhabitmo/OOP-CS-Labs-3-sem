using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandDisconnect : ICommand
{
    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState != null) return fileSystemState.Disconnect();

        return new CommandResultError { Message = "Something went wrong" };
    }
}