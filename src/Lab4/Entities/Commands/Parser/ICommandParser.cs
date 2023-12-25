using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Parser;

public interface ICommandParser
{
    CommandParserResult Parse(string commandString, FileSystemState fileSystemState);
}
