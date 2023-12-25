using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IMessage
{
    public Priority Priority { get; protected internal set; }
    public string Head { get; protected internal set; }
    public string Body { get; protected internal set; }
}