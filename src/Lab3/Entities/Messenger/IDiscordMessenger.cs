namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public interface IDiscordMessenger
{
    void SendDiscordMessage(IMessage? message);
}