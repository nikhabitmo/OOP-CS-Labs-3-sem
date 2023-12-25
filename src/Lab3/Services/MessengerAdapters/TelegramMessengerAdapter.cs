using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.MessengerAdapters;

public class TelegramMessengerAdapter : IMessenger
{
    private readonly ITelegramMessenger _telegramMessenger;

    public TelegramMessengerAdapter(ITelegramMessenger telegramMessenger)
    {
        _telegramMessenger = telegramMessenger ?? throw new ArgumentNullException(nameof(telegramMessenger));
    }

    public void SendMessage(IMessage? message)
    {
        _telegramMessenger.SendTelegramMessage(message);
    }
}