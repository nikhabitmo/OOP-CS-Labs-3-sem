using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    public MessengerRecipient(IMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        _messenger.SendMessage(message);
        return StatusReceivingMessage.Ok;
    }
}
