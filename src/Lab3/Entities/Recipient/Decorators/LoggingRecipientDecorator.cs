using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Decorators;

public class LoggingRecipientDecorator : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public LoggingRecipientDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        _recipient.ReceiveMessage(message);
        _logger.LogMessage(message, _recipient);

        return StatusReceivingMessage.Ok;
    }
}