using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandFileCopy : ICommand
{
    public CommandFileCopy(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; private set; }
    public string DestinationPath { get; private set; }

    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState != null) return fileSystemState.CopyFile(SourcePath, DestinationPath);

        return new CommandResultError { Message = "Something went wrong" };
    }
}