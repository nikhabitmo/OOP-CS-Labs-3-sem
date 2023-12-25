using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message : IMessage
{
    public Message()
    {
        Head = string.Empty;
        Body = string.Empty;
    }

    public Message(string head, string body, Priority priority = Priority.Low)
    {
        Head = head;
        Body = body;
        Priority = priority;
    }

    public string Head { get; set; }
    public string Body { get; set; }
    public Priority Priority { get; set; }
}