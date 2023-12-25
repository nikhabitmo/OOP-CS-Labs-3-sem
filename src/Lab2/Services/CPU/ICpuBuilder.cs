using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CPU;

public interface ICpuBuilder
{
    ICpuBuilder WithName(string name);
    ICpuBuilder WithSupportedSocket(Socket? socket);
    ICpuBuilder WithCoreFrequency(int coreFrequency);
    ICpuBuilder WithBuiltInVideoCore(bool hasBuiltInVideoCore);
    ICpuBuilder WithSupportedMemoryFrequencies(int supportedMemoryFrequencies);
    ICpuBuilder WithHeatDissipation(int heatDissipation);
    ICpuBuilder WithPowerConsumption(int powerConsumption);
    ICpuBuilder WithCoolingSystem(CoolingSystem coolingSystem);
    Cpu Build();
}