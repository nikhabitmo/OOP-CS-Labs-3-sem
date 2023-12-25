namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public record ObstaclesCounter(Obstacles.Entities.ObstacleBase Type, uint Counter)
{
    public Obstacles.Entities.ObstacleBase Type { get; private set; } = Type;
    public uint Counter { get; set; } = Counter;

    public void AddObstacle(uint number = 1)
    {
        Counter += number;
    }

    public void RemoveObstacle(uint number = 1)
    {
        if (Counter < number)
        {
            Counter = 0;
        }
        else
        {
            Counter -= number;
        }
    }
}