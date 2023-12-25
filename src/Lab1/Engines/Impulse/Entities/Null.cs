namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;

public class Null : ImpulseBase
{
    public Null()
    {
        Speed = 0;
        Time = 0;
        CoefficientOfFuelConsumption = Config.CoefficientOfFuelConsumption.Base;
    }
}