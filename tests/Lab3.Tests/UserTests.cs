using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UserTests
{
    [Fact]
    public void ReceiveMessageShouldLogAndReceiveMessage()
    {
        // Arrange
        var mockLogger = new Mock<ILogger>();
        var user = new User(Priority.Middle);
        var loggingUser = new LoggingUserDecorator(user, mockLogger.Object);

        var message = new UserMessage("Test", "Hello", Priority.Middle);

        // Act
        loggingUser.ReceiveMessage(message);

        // Assert
        mockLogger.Verify(logger => logger.LogMessage(message, user), Times.Once);
    }

    [Fact]
    public void MarkAsReadShouldNotLogAndMarkAsReadCauseOfProiority()
    {
        // Arrange
        var mockLogger = new Mock<ILogger>();
        var user = new User(Priority.High);
        var loggingUser = new LoggingUserDecorator(user, mockLogger.Object);

        var message = new UserMessage("Test", "Hello", Priority.Middle);
        user.ReceiveMessage(message);

        // Act
        Assert.ThrowsAny<ArgumentNullException>(() => loggingUser.MarkAsRead(message));
    }

    [Fact]
    public void MarkAsReadWithNullMessageShouldThrowArgumentNullException()
    {
        // Arrange
        var mockLogger = new Mock<ILogger>();
        var user = new User(Priority.High);
        var loggingUser = new LoggingUserDecorator(user, mockLogger.Object);

        // Act & Assert
        Assert.ThrowsAny<ArgumentNullException>(() => loggingUser.MarkAsRead(new UserMessage()));
    }
}