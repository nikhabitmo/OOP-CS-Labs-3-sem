namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

public class CosmoKits : Entities.ObstacleBase
{
    public CosmoKits()
    {
        Damage = Config.Damage.CosmoKits;
    }
}