using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Status;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

public abstract class DeflectorBase : DefenceBase
{
    protected DeflectorBase(ModifierBase? modifier = null)
    {
        Modifier = modifier;
    }

    public ModifierBase? Modifier { get; protected set; }

    public override ShipTravelResult TakeDamage(Obstacles.Entities.ObstacleBase? obstacleBase)
    {
        if (obstacleBase is Obstacles.Models.AntimatterFlares &&
            Modifier is not { DefenceAntiMatterFlares: > 1 })
        {
            return ShipTravelResult.Dead;
        }

        Modifier ??= new NullModifier();
        Modifier.DefenceAntiMatterFlares -= 1;

        if (HitPoints.Value > 0)
        {
            obstacleBase ??= new Obstacles.Models.Null();

            HitPoints = obstacleBase.MakeDamage(HitPoints);
        }

        return HitPoints.Value == 0 ? ShipTravelResult.Crushed : ShipTravelResult.Success;
    }
}