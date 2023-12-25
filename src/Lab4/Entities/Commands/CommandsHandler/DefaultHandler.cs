namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class DefaultHandler : ICommandHandler
{
    public ICommandHandler? NextHandler { get; set; }

    public ICommand? Handle(string[] args)
    {
        return null;
    }
}