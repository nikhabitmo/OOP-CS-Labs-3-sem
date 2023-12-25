using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandTreeList : ICommand
{
    private readonly int _depth;

    public CommandTreeList(int depth)
    {
        _depth = depth;
    }

    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState == null)
        {
            return new CommandResultError { Message = "File system state is null." };
        }

        var visitor = new TreeListVisitor(_depth);
        fileSystemState.TreeList(_depth, visitor);

        return new CommandResultSuccess { Message = "TreeList command executed successfully" };
    }
}