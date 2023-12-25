using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Services.MessengerAdapters;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void SendMessageShouldSendMessageToRecipient()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        var mockTelegramMessenger = new Mock<ITelegramMessenger>();
        var messenger = new Messenger(new TelegramMessengerAdapter(mockTelegramMessenger.Object));

        // Act
        messenger.ReceiveMessage(new Message("Test", "Hello"));

        // Assert
        mockTelegramMessenger.Verify(t => t.SendTelegramMessage(It.IsAny<IMessage>()), Times.Once);
    }

    [Fact]
    public void SendMessageWithNullRecipientShouldNotThrowException()
    {
        // Arrange
        var mockDiscordMesenger = new Mock<IDiscordMessenger>();
        var messenger = new Messenger(new DiscordMessengerAdapter(mockDiscordMesenger.Object));

        // Act & Assert
        Assert.Null(Record.Exception(() => messenger.ReceiveMessage(new Message("Test", "Hello"))));
    }
}