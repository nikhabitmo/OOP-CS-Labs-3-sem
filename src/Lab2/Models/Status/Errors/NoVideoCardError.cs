namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record NoVideoCardError() : ErrorWhileBuilding
{
    public new string Commentary { get; } = "There is no videocard with cpu which doesn't have installed videocard";
}