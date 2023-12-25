using Itmo.ObjectOrientedProgramming.Lab1.Units;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Config;

public static class Damage
{
    public static HitPoint Asteroid => new HitPoint(10);
    public static HitPoint Meteor => new HitPoint(20);
    public static HitPoint AnimatterFlares => new HitPoint();
    public static HitPoint CosmoKits => new HitPoint();
}