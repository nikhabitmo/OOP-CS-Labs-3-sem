namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class TreeGoToHandler : ICommandHandler
{
    public TreeGoToHandler(ICommandHandler? nextHandler)
    {
        NextHandler = nextHandler;
    }

    public ICommandHandler? NextHandler { get; set; }

    public ICommand? Handle(string[] args)
    {
        if (args?.Length >= 3 && args[0].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "tree" &&
            args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "goto")
        {
            return new CommandTreeGoTo(args[2]);
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}