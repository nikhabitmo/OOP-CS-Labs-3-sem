namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ITopic
{
    public void ReceiveMessage(IMessage message);
    public void PushMessage();
}