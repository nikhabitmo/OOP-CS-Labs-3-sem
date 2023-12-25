using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic : ITopic
{
    private IMessage? _message;

    public Topic(string name, IRecipient recipient)
    {
        Name = name;
        Recipient = recipient;
    }

    public string Name { get; private set; }
    public IRecipient Recipient { get; private set; }

    public void ReceiveMessage(IMessage message)
    {
        _message = message;
    }

    public void PushMessage()
    {
        Recipient.ReceiveMessage(_message);
    }
}