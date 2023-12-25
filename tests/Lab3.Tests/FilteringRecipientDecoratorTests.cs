using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class FilteringRecipientDecoratorTests
{
    [Fact]
    public void ReceiveMessageShouldReceiveMessageWhenPriorityIsNull()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        Priority filterLevel = Priority.High;
        var decorator = new FilteringRecipientDecorator(mockRecipient.Object, filterLevel);
        var message = new Message("Test", "Hello", Priority.Low);

        // Act
        decorator.ReceiveMessage(message);

        // Assert
        mockRecipient.Verify(r => r.ReceiveMessage(message), Times.Once);
    }

    [Fact]
    public void ReceiveMessageShouldReceiveMessageWhenPriorityIsEqualOrHigher()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        Priority filterLevel = Priority.Middle;
        var decorator = new FilteringRecipientDecorator(mockRecipient.Object, filterLevel);
        var message = new Message("Test", "Hello", Priority.High);

        // Act
        decorator.ReceiveMessage(message);

        // Assert
        mockRecipient.Verify(r => r.ReceiveMessage(message), Times.Never);
    }

    [Fact]
    public void ReceiveMessageShouldNotReceiveMessageWhenPriorityIsLower()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        Priority filterLevel = Priority.High;
        var decorator = new FilteringRecipientDecorator(mockRecipient.Object, filterLevel);
        var message = new Message("Test", "Hello", Priority.Middle);

        // Act
        decorator.ReceiveMessage(message);

        // Assert
        mockRecipient.Verify(r => r.ReceiveMessage(It.IsAny<IMessage>()), Times.Once);
    }
}