namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class DisconnectHandler : ICommandHandler
{
    public DisconnectHandler(ICommandHandler? nextHandler)
    {
        NextHandler = nextHandler;
    }

    public ICommandHandler? NextHandler { get; set; }

    public ICommand? Handle(string[] args)
    {
        if (args?.Length == 1 && args[0].ToLower(System.Globalization.CultureInfo.CurrentCulture) == "disconnect")
        {
            return new CommandDisconnect();
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}