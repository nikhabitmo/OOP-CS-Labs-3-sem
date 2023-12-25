using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class UserMessage : IUserMessage
{
    private bool _isViewed;

    public UserMessage(string head, string body, Priority priority)
    {
        Head = head;
        Body = body;
        Priority = priority;
        _isViewed = false;
    }

    public UserMessage()
    {
        Head = string.Empty;
        Body = string.Empty;
        Priority = Priority.Low;
    }

    public string Head { get; set; }
    public string Body { get; set; }
    public Priority Priority { get; set; }

    public bool IsViewed
    {
        get => _isViewed;
        set => _isViewed = value;
    }

    public IMessage MarkAsRead()
    {
        if (_isViewed)
        {
            throw new InvalidOperationException("The message is already read.");
        }

        _isViewed = true;
        return this;
    }

    public void SetMessage(string head, string body)
    {
        Head = head;
        Body = body;
    }
}