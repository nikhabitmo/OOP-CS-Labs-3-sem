namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result;

public record ErrorWhileBuilding : BuildingPCResult
{
    public new string? Commentary { get; } = "There was some error while building";
}