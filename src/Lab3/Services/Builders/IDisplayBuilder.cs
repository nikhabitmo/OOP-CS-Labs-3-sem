namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public interface IDisplayBuilder : IReceiverBuilder
{
    IDisplayBuilder WithDisplayDriver();
}