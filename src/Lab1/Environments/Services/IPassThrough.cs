using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public interface IPassThrough
{
    public ShipTravelResult CanGoThroughSegment(
        SpaceShips.Entities.SpaceShipBase? ship,
        Entities.EnvironmentBase? environment)
    {
        if (ship == null) throw new ArgumentNullException(nameof(ship));

        return environment switch
        {
            null => throw new ArgumentNullException(nameof(environment)),
            Space => environment.PassThrough(ship),
            ParticleNitrineNebula => environment.PassThrough(ship),
            IncreasedDensityNebula => environment.PassThrough(ship),
            _ => ShipTravelResult.Crushed,
        };
    }
}