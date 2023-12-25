using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class Messenger
{
    private readonly IMessenger _messenger;

    public Messenger(IMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void ReceiveMessage(IMessage? message)
    {
        _messenger.SendMessage(message);
    }
}