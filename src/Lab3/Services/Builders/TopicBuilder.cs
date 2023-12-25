using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class TopicBuilder : ITopicBuilder
{
    private string _name;
    private IRecipient? _recipient;

    public TopicBuilder()
    {
        _name = string.Empty;
    }

    public ITopicBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ITopicBuilder WithReceiver(IRecipient recipient)
    {
        _recipient = recipient;
        return this;
    }

    public ITopic Build()
    {
        if (string.IsNullOrEmpty(_name) || _recipient == null)
        {
            throw new InvalidOperationException("Topic name and Recipient must be set.");
        }

        return new Topic(_name, _recipient);
    }
}