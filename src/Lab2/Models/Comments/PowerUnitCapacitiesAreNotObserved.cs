namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Comments;

public record PowerUnitCapacitiesAreNotObserved
{
    public string Comment { get; private set; } = "The recommended capacities are not observed";
}