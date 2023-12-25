using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RAM;

public interface IRamBuilder
{
    IRamBuilder WithName(string name);
    IRamBuilder WithFormFactor(string formFactor);
    IRamBuilder WithDdrStandardVersion(string ddrStandardVersion);
    IRamBuilder WithSupportedXmpAndDocProfiles(IEnumerable<string> supportedProfiles);
    IRamBuilder WithAvailableMemorySize(int memorySize);
    IRamBuilder WithPowerConsumption(double powerConsumption);
    IRamBuilder WithSupportedJedecFrequencyAndVoltage(double frequency, double voltage);
    Ram Build();
}