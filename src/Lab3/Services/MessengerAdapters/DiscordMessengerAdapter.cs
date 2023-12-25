using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.MessengerAdapters;

public class DiscordMessengerAdapter : IMessenger
{
    private readonly IDiscordMessenger _discordMessenger;

    public DiscordMessengerAdapter(IDiscordMessenger discordMessenger)
    {
        _discordMessenger = discordMessenger ?? throw new ArgumentNullException(nameof(discordMessenger));
    }

    public void SendMessage(IMessage? message)
    {
        _discordMessenger.SendDiscordMessage(message);
    }
}