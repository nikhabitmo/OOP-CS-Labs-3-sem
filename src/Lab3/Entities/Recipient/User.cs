using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;

public class User : IRecipient
{
    public User(Priority priority)
    {
        Priority = priority;
    }

    public IList<IUserMessage> ReceivedMessages { get; private set; } = new List<IUserMessage>();
    public Priority Priority { get; private set; }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        if (message == null)
        {
            ReceivedMessages.Add(new UserMessage());
            return StatusReceivingMessage.Error;
        }

        if (Priority <= message.Priority)
        {
            ReceivedMessages.Add(new UserMessage(message.Head, message.Body, message.Priority));
        }

        return StatusReceivingMessage.Ok;
    }

    public StatusReceivingMessage MarkAsRead(IUserMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));

        if (ReceivedMessages.Contains(message))
        {
            if (!message.IsViewed)
            {
                message.MarkAsRead();
                return StatusReceivingMessage.Ok;
            }
        }

        return StatusReceivingMessage.Error;
    }
}
