using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class Space : EnvironmentBase
{
    public Space(uint numberOfAsteroids = 0, uint numberOfMeteors = 0)
    {
        AddNewObstacleType(new Asteroid(), numberOfAsteroids);
        AddNewObstacleType(new Meteor(), numberOfMeteors);
    }

    public override ShipTravelResult PassThrough(SpaceShipBase? ship)
    {
        if (ship == null) throw new ArgumentNullException(nameof(ship));
        if (!IsTypeOfEngineMatches(ship.ImpulseEngine)) return ShipTravelResult.Crushed;

        foreach (ObstaclesCounter obstacle in Obstacles)
        {
            for (int i = 0; i < obstacle.Counter; ++i)
            {
                ShipTravelResult status = ship.TakeDamage(obstacle.Type);
                if (status == ShipTravelResult.Success) obstacle.RemoveObstacle();
                else return status;
            }
        }

        ship.ConsumptedFuel += ship.ImpulseEngine.CalculateFuelConsumption();
        ship.ConsumptedFuel += ship.JumpingEngine.CalculateFuelConsumption();

        return ShipTravelResult.Success;
    }

    protected override bool IsTypeOfEngineMatches(EngineBase? engineBase)
    {
        if (engineBase == null) return false;
        return engineBase is ImpulseBase;
    }
}