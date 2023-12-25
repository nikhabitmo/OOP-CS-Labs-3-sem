namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record RamDoesntSupportedError() : ErrorWhileBuilding
{
    public new string? Commentary { get; } = "The ram couldn't be supported";
}