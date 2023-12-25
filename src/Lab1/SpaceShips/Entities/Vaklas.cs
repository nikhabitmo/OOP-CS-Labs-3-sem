using Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

public class Vaklas : Entities.SpaceShipBase
{
    public Vaklas(ModifierBase? modifier = null)
        : base(
            new Protection.Frames.Models.B(),
            new E(),
            new Protection.Deflectors.Models.A(modifier),
            new Engines.Jump.Models.Gamma())
    {
        Type = TypeOfShip.Research;
    }
}