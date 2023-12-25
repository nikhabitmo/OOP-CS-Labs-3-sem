namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;

public class E : ImpulseBase
{
    public E()
    {
        Speed = Config.Speed.E;
        Time = Config.Time.E;
        CoefficientOfFuelConsumption = Config.CoefficientOfFuelConsumption.E;
    }
}