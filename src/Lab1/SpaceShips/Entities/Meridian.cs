using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

public class Meridian : Entities.SpaceShipBase
{
    public Meridian(ModifierBase? modifier = null)
        : base(
            new Protection.Frames.Models.B(),
            new Engines.Impulse.Entities.E(),
            new A(modifier),
            new Engines.Jump.Models.Gamma())
    {
        Type = TypeOfShip.Mining;
        AntiNitrineEmitter = true;
    }
}