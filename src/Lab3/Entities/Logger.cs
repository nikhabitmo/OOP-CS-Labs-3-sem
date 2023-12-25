using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Logger : ILogger
{
    public void LogMessage(IMessage? message, IRecipient recipient)
    {
        Console.WriteLine("THe message was sent to the recipient");
    }
}