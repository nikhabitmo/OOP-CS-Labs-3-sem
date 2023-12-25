namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class DeleteHandler : ICommandHandler
{
    public DeleteHandler(ICommandHandler? nextHandler)
    {
        NextHandler = nextHandler;
    }

    public ICommandHandler? NextHandler { get; set; }

    public ICommand? Handle(string[] args)
    {
        if (args?.Length >= 3 && args[1].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "delete")
        {
            return new CommandDelete(args[2]);
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}
