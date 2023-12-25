using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class FileShowHandler : ICommandHandler
{
    public FileShowHandler(ICommandHandler? nextHandler)
    {
        NextHandler = nextHandler;
    }

    public ICommandHandler? NextHandler { get; set; }

    public ICommandHandler? SetNext(ICommandHandler? handler)
    {
        NextHandler = handler;
        return handler;
    }

    public ICommand? Handle(string[] args)
    {
        if (args?.Length >= 4 && args[0].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "file" &&
            args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "show" &&
            args[3].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "-m")
        {
            return new CommandFileShow(args[2], new ConsoleOutputMode());
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}