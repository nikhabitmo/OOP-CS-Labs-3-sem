using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Decorators;

public class FilteringRecipientDecorator : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly Priority _filterLevel;

    public FilteringRecipientDecorator(IRecipient recipient, Priority filterLevel)
    {
        _recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _filterLevel = filterLevel;
    }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        if (message != null && message.Priority >= _filterLevel)
        {
            _recipient.ReceiveMessage(message);
        }

        return StatusReceivingMessage.Ok;
    }
}