namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

public class Meteor : Entities.ObstacleBase
{
    public Meteor()
    {
        Damage = Config.Damage.Meteor;
    }
}