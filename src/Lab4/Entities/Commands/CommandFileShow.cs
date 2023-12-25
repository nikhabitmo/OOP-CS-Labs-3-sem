using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CommandFileShow : ICommand
{
    public CommandFileShow(string path, OutputMode outputMode)
    {
        Path = path;
        OutputMode = outputMode;
    }

    public string Path { get; private set; }

    public OutputMode OutputMode { get; private set; }
    public CommandResult Execute(FileSystemState? fileSystemState)
    {
        if (fileSystemState != null) return fileSystemState.ShowFile(Path, OutputMode);

        return new CommandResultError { Message = "Something went wrong" };
    }
}