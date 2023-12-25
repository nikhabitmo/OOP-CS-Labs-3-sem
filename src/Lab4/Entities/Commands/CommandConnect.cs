using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandConnect : ICommand
{
    public CommandConnect(string address, FileSystemMode fileSystemMode)
    {
        Address = address;
        FileSystemMode = fileSystemMode;
    }

    public string Address { get; private set; }

    public FileSystemMode FileSystemMode { get; private set; }

    public Dictionary<string, string> DynamicParameters { get; private set; } = new Dictionary<string, string>();

    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState != null) return fileSystemState.Connect(Address, FileSystemMode);

        return new CommandResultError { Message = "Something went wrong" };
    }
}