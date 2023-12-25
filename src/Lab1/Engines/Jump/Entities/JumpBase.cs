namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Entities;

public abstract class JumpBase : EngineBase
{
    public int Distance { get; protected init; }

    public override double CalculateFuelConsumption()
    {
        return Speed;
    }
}