namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

public class Asteroid : Entities.ObstacleBase
{
    public Asteroid()
    {
        Damage = Config.Damage.Asteroid;
    }
}