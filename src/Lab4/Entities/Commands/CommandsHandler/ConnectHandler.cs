using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandsHandler;

public class ConnectHandler : ICommandHandler
{
    public ConnectHandler(ICommandHandler? nextHandler)
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
        if (args?.Length >= 2 && string.Equals(args[0], "connect", StringComparison.Ordinal))
        {
            if (args.Length >= 4 && string.Equals(args[2], "-m", StringComparison.Ordinal))
            {
                return new CommandConnect(args[1], new LocalFileSystemMode());
            }
        }

        return args != null ? NextHandler?.Handle(args) : null;
    }
}