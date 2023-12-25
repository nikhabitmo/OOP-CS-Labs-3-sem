using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class MessageSystem
{
    private List<Topic> _topics = new List<Topic>();

    public static void SendMessage(string topicName, IMessage message, IRecipient recipient)
    {
        var topic = new Topic(topicName, recipient);
        topic.ReceiveMessage(message);
        topic.PushMessage();
    }

    public void AddTopic(Topic topic)
    {
        _topics.Add(topic);
    }

    public void RemoveTopic(Topic topic)
    {
        _topics.Remove(topic);
    }

    public void SendAllMessages()
    {
        foreach (Topic topic in _topics)
        {
            topic.PushMessage();
        }
    }
}