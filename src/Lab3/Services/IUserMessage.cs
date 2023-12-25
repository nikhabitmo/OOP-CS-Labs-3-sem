using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IUserMessage : IMessage
{
    public bool IsViewed { get; protected set; }
    public IMessage MarkAsRead();
}