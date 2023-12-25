using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    public Route(IReadOnlyList<EnvironmentBase> environments)
    {
        Environments = environments;
    }

    private IReadOnlyList<EnvironmentBase> Environments { get; }

    public ShipTravelResult PassRoute(SpaceShipBase? ship)
    {
        return Environments.Select(environment => environment.PassThrough(ship))
            .FirstOrDefault(status => status != ShipTravelResult.Success);
    }
}