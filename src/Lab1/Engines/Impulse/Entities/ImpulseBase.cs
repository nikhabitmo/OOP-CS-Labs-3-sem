namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;

public abstract class ImpulseBase : EngineBase
{
    protected double CoefficientOfFuelConsumption { get; init; }
    protected double Time { get; init; }
    public override double CalculateFuelConsumption()
    {
        return Time * Speed / CoefficientOfFuelConsumption;
    }
}