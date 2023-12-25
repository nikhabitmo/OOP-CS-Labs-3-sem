using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;

public class A : DeflectorBase
{
    public A(ModifierBase? modifier = null)
    {
        HitPoints = Config.HitPoints.A;
        Modifier = modifier;
    }
}