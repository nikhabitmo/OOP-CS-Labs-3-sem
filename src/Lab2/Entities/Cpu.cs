using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IComponent
{
    public Cpu(CoolingSystem coolingSystem)
    {
        Name = string.Empty;
        SupportedSocket = new EmptySocket();
        CoolingSystem = coolingSystem;
    }

    public Cpu(
        string name,
        Socket supportedSocket,
        int coreFrequency,
        bool builtInVideoCore,
        int supportedMemoryFrequencies,
        int heatDissipation,
        int powerConsumption,
        CoolingSystem coolingSystem)
    {
        Name = name;
        SupportedSocket = supportedSocket;
        CoreFrequency = coreFrequency;
        BuiltInVideoCore = builtInVideoCore;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        HeatDissipation = heatDissipation;
        PowerConsumption = powerConsumption;
        CoolingSystem = coolingSystem;
    }

    public string Name { get; set; }
    public int CoreFrequency { get; private set; }
    public bool BuiltInVideoCore { get; private set; }
    public int SupportedMemoryFrequencies { get; private set; }
    public int HeatDissipation { get; private set; }
    public Socket SupportedSocket { get; private set; }
    public int PowerConsumption { get; private set; }
    public CoolingSystem CoolingSystem { get; private set; }

    public Cpu Clone()
    {
        return new Cpu(
            Name,
            SupportedSocket.Clone(),
            CoreFrequency,
            BuiltInVideoCore,
            SupportedMemoryFrequencies,
            HeatDissipation,
            PowerConsumption,
            CoolingSystem.Clone());
    }
}