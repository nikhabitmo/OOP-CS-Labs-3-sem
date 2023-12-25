namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;

public class C : ImpulseBase
{
    public C()
    {
        Speed = Config.Speed.C;
        Time = Config.Time.C;
        CoefficientOfFuelConsumption = Config.CoefficientOfFuelConsumption.C;
    }
}