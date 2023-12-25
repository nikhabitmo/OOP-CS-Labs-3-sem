using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class ParticleNitrineNebula : Entities.EnvironmentBase
{
    public ParticleNitrineNebula(uint numberOfCosmoKits = 0)
    {
        AddNewObstacleType(new CosmoKits(), numberOfCosmoKits);
    }

    public override ShipTravelResult PassThrough(SpaceShipBase? ship)
    {
        if (ship == null) throw new ArgumentNullException(nameof(ship));
        if (!IsTypeOfEngineMatches(ship.JumpingEngine)) return ShipTravelResult.Crushed;

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
        return engineBase is JumpBase;
    }
}