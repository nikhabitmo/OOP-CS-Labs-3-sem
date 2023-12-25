namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class RenameHandler : ICommandHandler
{
    public RenameHandler(ICommandHandler? nextHandler)
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
            args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "rename")
        {
            return new CommandRename(args[2], args[3]);
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}