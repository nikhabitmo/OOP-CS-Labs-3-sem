using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;

public class C : DeflectorBase
{
    public C(ModifierBase? modifier = null)
    {
        HitPoints = Config.HitPoints.C;
        Modifier = modifier;
    }
}