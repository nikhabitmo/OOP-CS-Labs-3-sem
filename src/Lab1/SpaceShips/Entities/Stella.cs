using Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

public class Stella : Entities.SpaceShipBase
{
    public Stella(ModifierBase? modifier = null)
        : base(
            new Protection.Frames.Models.A(),
            new C(),
            new Protection.Deflectors.Models.A(modifier),
            new Engines.Jump.Models.Alpha())
    {
        Type = TypeOfShip.Diplomatic;
    }
}