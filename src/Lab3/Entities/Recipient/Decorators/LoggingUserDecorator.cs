using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Decorators;

public class LoggingUserDecorator : IRecipient
{
    private readonly User _user;
    private readonly ILogger _logger;

    public LoggingUserDecorator(User user, ILogger logger)
    {
        _user = user ?? throw new ArgumentNullException(nameof(user));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        StatusReceivingMessage status = _user.ReceiveMessage(message);
        if (status == StatusReceivingMessage.Error)
        {
            _logger.LogMessage(new Message("Error", "The message wasn't received"), _user);
            return StatusReceivingMessage.Error;
        }

        _logger.LogMessage(message, _user);
        return StatusReceivingMessage.Ok;
    }

    public StatusReceivingMessage MarkAsRead(IUserMessage? message)
    {
        if (message == null || !_user.ReceivedMessages.Contains(message))
        {
            throw new ArgumentNullException(nameof(message));
        }

        StatusReceivingMessage status = _user.MarkAsRead(message);
        if (status == StatusReceivingMessage.Error)
        {
            _logger.LogMessage(new Message("Error", "The message wasn't received"), _user);
            return StatusReceivingMessage.Error;
        }

        _logger.LogMessage(new Message("All messages", "were marked as read "), _user);

        return StatusReceivingMessage.Ok;
    }
}