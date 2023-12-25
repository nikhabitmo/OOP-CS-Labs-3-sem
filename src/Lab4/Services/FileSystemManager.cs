using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class FileSystemManager
{
    private FileSystemState _fileSystemState;
    private ParserCommands _parserCommands;

    public FileSystemManager(FileSystemState fileSystemState, ParserCommands parserCommands)
    {
        _fileSystemState = fileSystemState;
        _parserCommands = parserCommands;
    }

    public CommandParserResult ParseCommand(string command)
    {
        return _parserCommands.Parse(command, _fileSystemState);
    }
}