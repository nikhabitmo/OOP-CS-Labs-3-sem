using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TopicTests
{
    [Fact]
    public void PushMessageShouldSendMessageToRecipient()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        var topic = new Topic("Test Topic", mockRecipient.Object);
        var message = new Message("Test", "Hello", Priority.Middle);

        // Act
        topic.ReceiveMessage(message);
        topic.PushMessage();

        // Assert
        mockRecipient.Verify(r => r.ReceiveMessage(message), Times.Once);
    }

    [Fact]
    public void PushMessageWithNullRecipientShouldNotThrowException()
    {
        // Arrange
        var user = new User(Priority.Low);
        var topic = new Topic("Test Topic", user);
        var message = new Message("Test", "Hello", Priority.Middle);
        topic.ReceiveMessage(message);

        // Act & Assert
        Assert.Null(Record.Exception(() => topic.PushMessage()));
    }

    [Fact]
    public void PushMessageWithNullMessageShouldNotThrowException()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        var topic = new Topic("Test Topic", mockRecipient.Object);

        // Act & Assert
        Assert.Null(Record.Exception(() => topic.PushMessage()));
    }
}