namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public interface ICommandHandler
{
    ICommandHandler? NextHandler { get; protected set; }
    ICommand? Handle(string[] args);
}