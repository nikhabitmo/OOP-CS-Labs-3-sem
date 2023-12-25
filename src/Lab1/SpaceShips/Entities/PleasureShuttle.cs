using Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

public class PleasureShuttle : Entities.SpaceShipBase
{
    public PleasureShuttle()
        : base(
            new Protection.Frames.Models.A(),
            new C())
    {
        Type = TypeOfShip.Basic;
    }
}