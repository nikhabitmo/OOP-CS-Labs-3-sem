using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public interface IRecipient
{
    public StatusReceivingMessage ReceiveMessage(IMessage? message);
}