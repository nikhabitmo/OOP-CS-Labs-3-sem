using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class DisplayRecipientTests
{
    [Fact]
    public void ReceiveMessageShouldShowMessageOnDisplay()
    {
        // Arrange
        var mockDisplay = new Mock<Display>();
        var displayRecipient = new DisplayRecipient(mockDisplay.Object);
        var mockMessage = new Mock<IMessage>();

        // Act
        StatusReceivingMessage result = displayRecipient.ReceiveMessage(mockMessage.Object);

        // Assert
        mockDisplay.Verify(d => d.ShowMessage(It.IsAny<string>(), It.IsAny<ConsoleColor>()), Times.Once);
        Assert.Equal(StatusReceivingMessage.Ok, result);
    }

    [Fact]
    public void ReceiveMessageWithNullMessageShouldReturnError()
    {
        // Arrange
        var mockDisplay = new Mock<Display>();
        var displayRecipient = new DisplayRecipient(mockDisplay.Object);

        // Act
        StatusReceivingMessage result = displayRecipient.ReceiveMessage(null);

        // Assert
        mockDisplay.Verify(d => d.ShowMessage(It.IsAny<string>(), It.IsAny<ConsoleColor>()), Times.Never);
        Assert.Equal(StatusReceivingMessage.Error, result);
    }
}