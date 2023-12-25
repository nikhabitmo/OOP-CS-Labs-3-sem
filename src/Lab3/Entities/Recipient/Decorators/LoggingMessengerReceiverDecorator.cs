using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Decorators;

public class LoggingMessengerReceiverDecorator : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public LoggingMessengerReceiverDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        if (message != null)
        {
            _logger.LogMessage(new Message("Messenger: " + message.Head, message.Body, message.Priority), _recipient);
            _recipient.ReceiveMessage(message);
            return StatusReceivingMessage.Ok;
        }

        _logger.LogMessage(new Message("Null", "Message was received"), _recipient);

        return StatusReceivingMessage.Ok;
    }
}