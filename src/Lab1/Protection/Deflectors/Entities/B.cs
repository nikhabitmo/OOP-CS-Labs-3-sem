using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;

public class B : DeflectorBase
{
    public B(ModifierBase? modifier = null)
    {
        HitPoints = Config.HitPoints.B;
        Modifier = modifier;
    }
}