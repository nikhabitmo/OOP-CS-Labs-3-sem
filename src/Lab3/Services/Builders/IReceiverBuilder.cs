using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public interface IReceiverBuilder
{
    IReceiverBuilder WithPriority(Priority priority);
    IRecipient Build();
}