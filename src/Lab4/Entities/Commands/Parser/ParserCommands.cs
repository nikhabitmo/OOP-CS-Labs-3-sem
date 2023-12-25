using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Parser;

public class ParserCommands : ICommandParser
{
    public ParserCommands()
    {
    }

    public ICommandHandler? CommandHandlerChain { get; set; } = new ConnectHandler(
        new FileMoveHandler(
            new DeleteHandler(
                new FileCopyHandler(
                    new RenameHandler(
                        new TreeListHandler(
                            new TreeGoToHandler(
                                new DisconnectHandler(
                                    new DefaultHandler()))))))));

    public CommandParserResult Parse(string commandString, FileSystemState fileSystemState)
    {
        if (commandString == null) return new CommandParserResultError() { Message = "Command not recognized" };

        string[] args = commandString.Split(' ');

        if (args.Length > 0)
        {
            ICommandHandler? currentHandler = CommandHandlerChain;

            while (currentHandler != null)
            {
                ICommand? command = currentHandler.Handle(args);
                if (command != null && currentHandler.NextHandler is not null)
                {
                    command.Execute(fileSystemState);
                    return new CommandParserResultSuccess() { Message = $"Handler found {currentHandler}" };
                }

                currentHandler = currentHandler.NextHandler;
            }
        }

        return new CommandParserResultError() { Message = "Command was not recognized" };
    }
}