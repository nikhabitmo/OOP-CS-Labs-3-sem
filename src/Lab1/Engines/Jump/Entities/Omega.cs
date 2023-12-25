using Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Models;

public class Omega : JumpBase
{
    public Omega()
    {
        Speed = Jump.Config.Speed.Omega;
        Distance = Config.Distance.Omega;
    }

    public override double CalculateFuelConsumption()
    {
        return Distance / Speed * double.Log(Speed);
    }
}