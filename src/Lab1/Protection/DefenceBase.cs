using Itmo.ObjectOrientedProgramming.Lab1.Status;
using Itmo.ObjectOrientedProgramming.Lab1.Units;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection;

public abstract class DefenceBase
{
    protected DefenceBase()
    {
        HitPoints = new HitPoint();
    }

    protected DefenceBase(HitPoint hitPoints)
    {
        HitPoints = hitPoints;
    }

    protected HitPoint HitPoints { get; set; }

    public virtual ShipTravelResult TakeDamage(Obstacles.Entities.ObstacleBase? obstacleBase)
    {
        if (HitPoints.Value > 0)
        {
            obstacleBase ??= new Obstacles.Models.Null();

            HitPoints = obstacleBase.MakeDamage(HitPoints);
        }

        if (HitPoints.Value == 0)
        {
            return ShipTravelResult.Crushed;
        }

        return ShipTravelResult.Success;
    }
}