namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public abstract class CommandHandler : ICommandHandler
{
    public ICommandHandler? NextHandler { get; set; }

    public virtual ICommand? Handle(string[] args)
    {
        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}