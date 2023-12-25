using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
public abstract class EnvironmentBase
{
    internal List<ObstaclesCounter> Obstacles { get; } = new List<ObstaclesCounter>();

    public void AddObstacles(Obstacles.Entities.ObstacleBase obstacle, uint counter)
    {
        ObstaclesCounter? existingObstacle = Obstacles.FirstOrDefault(o => o.Type == obstacle);
        if (existingObstacle != null)
        {
            existingObstacle.Counter += counter;
        }
        else
        {
            AddNewObstacleType(obstacle, counter);
        }
    }

    public abstract ShipTravelResult PassThrough(SpaceShips.Entities.SpaceShipBase? ship);

    public bool AreAnyObstaclesLeft()
    {
        return Obstacles.Sum(obstacle => obstacle.Counter) != 0;
    }

    public void RemoveObstacles(Obstacles.Entities.ObstacleBase obstacle, uint counter)
    {
        ObstaclesCounter? existingObstacle = Obstacles.FirstOrDefault(o => o.Type == obstacle);
        if (existingObstacle != null)
        {
            existingObstacle.RemoveObstacle(counter);
        }
        else
        {
            AddNewObstacleType(obstacle, counter);
        }
    }

    protected abstract bool IsTypeOfEngineMatches(EngineBase? engineBase);

    protected void AddNewObstacleType(Obstacles.Entities.ObstacleBase obstacle, uint counter)
    {
        Obstacles.Add(new ObstaclesCounter(obstacle, counter));
    }
}