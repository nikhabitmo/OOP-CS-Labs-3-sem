using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Microsoft.Extensions.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public interface ITopicBuilder
{
    ITopicBuilder WithName(string name);

    ITopicBuilder WithReceiver(IRecipient recipient);
    ITopic Build();
}
