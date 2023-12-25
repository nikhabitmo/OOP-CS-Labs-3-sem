namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;

public abstract record CommandResult()
{
    public string? Message { get; set; }
}