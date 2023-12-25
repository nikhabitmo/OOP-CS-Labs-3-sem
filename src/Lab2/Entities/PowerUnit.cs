using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerUnit : IComponent
{
    public PowerUnit(string name, int peakLoad = 0)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public string Name { get; set; }
    public int PeakLoad { get; private set; }
    public PowerUnit Clone()
    {
        return new PowerUnit(Name, PeakLoad);
    }
}