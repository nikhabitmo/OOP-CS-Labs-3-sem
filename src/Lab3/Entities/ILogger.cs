using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ILogger
{
    void LogMessage(IMessage? message, IRecipient recipient);
}