using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Status;
using Null = Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Models.Null;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class IncreasedDensityNebula : Entities.EnvironmentBase
{
    public IncreasedDensityNebula(uint numberOfAntimatterFlares = 0)
    {
        AddNewObstacleType(new AntimatterFlares(), numberOfAntimatterFlares);
        Distance = Config.Distance.IncreasedDensityNebula;
    }

    private int Distance { get; set; }

    public override ShipTravelResult PassThrough(SpaceShipBase? ship)
    {
        if (ship == null) throw new ArgumentNullException(nameof(ship));
        if (!IsTypeOfEngineMatches(ship.JumpingEngine)) return ShipTravelResult.Lost;
        if (!CanOvercomeDistance(ship.JumpingEngine)) return ShipTravelResult.Lost;

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

    private bool CanOvercomeDistance(JumpBase? jumpBase)
    {
        jumpBase ??= new Null();
        return jumpBase.Distance > Distance;
    }
}