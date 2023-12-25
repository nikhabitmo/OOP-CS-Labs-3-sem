using Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Models;

public class Gamma : JumpBase
{
    public Gamma()
    {
        Speed = Config.Speed.Gamma;
        Distance = Config.Distance.Gamma;
    }

    public override double CalculateFuelConsumption()
    {
        return Distance / Speed * Speed;
    }
}