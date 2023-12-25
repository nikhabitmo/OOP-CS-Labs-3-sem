using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : IComponent
{
    public Ram(
        string name,
        string formFactor,
        string ddrStandartVersion,
        IEnumerable<string> supportedXmpAndDocPprofiles,
        int amountOfAvailableMemorySize,
        double powerConsumption,
        double supportedJedecFrequency,
        double voltage)
    {
        Name = name;
        FormFactor = formFactor;
        DdrStandartVersion = ddrStandartVersion;
        SupportedXmpAndDocPprofiles = supportedXmpAndDocPprofiles;
        AmountOfAvailableMemorySize = amountOfAvailableMemorySize;
        PowerConsumption = powerConsumption;
        SupportedJedecFrequency = supportedJedecFrequency;
        Voltage = voltage;
    }

    public string Name { get; set; }
    public string FormFactor { get; private set; }
    public string DdrStandartVersion { get; private set; }
    public IEnumerable<string> SupportedXmpAndDocPprofiles { get; private set; }
    public int AmountOfAvailableMemorySize { get; private set; }
    public double PowerConsumption { get; private set; }
    public double SupportedJedecFrequency { get; private set; }
    public double Voltage { get; private set; }
    public Ram Clone()
    {
        return new Ram(
            Name,
            FormFactor,
            DdrStandartVersion,
            SupportedXmpAndDocPprofiles,
            AmountOfAvailableMemorySize,
            PowerConsumption,
            SupportedJedecFrequency,
            Voltage);
    }
}