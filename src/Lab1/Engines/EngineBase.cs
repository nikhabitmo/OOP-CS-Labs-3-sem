namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class EngineBase
{
    protected double Speed { get; set; }

    public abstract double CalculateFuelConsumption();
}