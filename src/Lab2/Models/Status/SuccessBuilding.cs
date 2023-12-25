namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result;

public record SuccessBuilding : BuildingPCResult
{
    public SuccessBuilding(string? comment = null)
    {
        Commentary = comment;
    }
}