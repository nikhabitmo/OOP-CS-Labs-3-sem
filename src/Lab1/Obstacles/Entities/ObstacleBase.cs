using System;
using Itmo.ObjectOrientedProgramming.Lab1.Units;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public abstract class ObstacleBase
{
    protected HitPoint? Damage { get; init; }

    public HitPoint MakeDamage(HitPoint hitPoints)
    {
        if (hitPoints == null) throw new ArgumentNullException(nameof(hitPoints));
        return Damage == null ? hitPoints : hitPoints.Lose(Damage);
    }
}