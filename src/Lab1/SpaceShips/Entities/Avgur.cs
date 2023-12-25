using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

public class Avgur : Entities.SpaceShipBase
{
    public Avgur(ModifierBase? modifier = null)
        : base(
            new Protection.Frames.Models.B(),
            new Engines.Impulse.Entities.E(),
            new Protection.Deflectors.Models.C(modifier),
            new Engines.Jump.Models.Alpha())
    {
        Type = TypeOfShip.Fight;
    }
}