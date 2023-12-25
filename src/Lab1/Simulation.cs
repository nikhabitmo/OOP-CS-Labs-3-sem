using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Simulation
{
    public Simulation(Route route, params SpaceShipBase[] spaceShips)
    {
        Route = route;
        SpaceShips = spaceShips.Any()
            ? spaceShips.ToList()
            : GetDefaultSpaceShips();
    }

    private Route Route { get; }

    private List<SpaceShipBase> SpaceShips { get; }

    public SpaceShipBase GetMostBenefitShip()
    {
        SpaceShipBase? bestShip = SpaceShips
                                      .Where(ship => Route.PassRoute(ship) == ShipTravelResult.Success)
                                      .MinBy(ship => ship.ConsumptedFuel) ??
                                  SpaceShips.MinBy(ship => ship.JumpingEngine.Distance);

        if (bestShip == null)
        {
            throw new InvalidOperationException("There ain't ships to get this route succesfully.");
        }

        return bestShip;
    }

    public ShipTravelResult PassThrough(SpaceShipBase ship)
    {
        return Route.PassRoute(ship);
    }

    private static List<SpaceShipBase> GetDefaultSpaceShips()
    {
        return new List<SpaceShipBase>
        {
            new Meridian(),
            new Avgur(),
            new Stella(),
            new PleasureShuttle(),
            new Vaklas(),
        };
    }
}