namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public interface ITelegramMessenger
{
    void SendTelegramMessage(IMessage? message);
}