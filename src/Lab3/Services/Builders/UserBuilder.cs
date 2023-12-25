using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class UserBuilder : IReceiverBuilder
{
    private Priority _priority;

    public UserBuilder()
    {
        _priority = Priority.Low;
    }

    public IReceiverBuilder WithPriority(Priority priority)
    {
        _priority = priority;
        return this;
    }

    public IRecipient Build()
    {
        return new User(_priority);
    }
}