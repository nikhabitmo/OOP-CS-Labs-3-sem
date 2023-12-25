using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Units;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;

public class NullDeflector : DeflectorBase
{
    public NullDeflector()
    {
        HitPoints = new HitPoint();
    }
}