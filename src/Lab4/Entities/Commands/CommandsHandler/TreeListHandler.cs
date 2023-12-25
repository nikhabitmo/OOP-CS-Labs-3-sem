namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class TreeListHandler : ICommandHandler
{
    public TreeListHandler(ICommandHandler? nextHandler)
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
        if (args?.Length >= 3 && args[0].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "tree" &&
            args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "list" &&
            args[2].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "-d")
        {
            if (args.Length >= 4 && int.TryParse(args[3], out int depth))
            {
                return new CommandTreeList(depth);
            }
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}