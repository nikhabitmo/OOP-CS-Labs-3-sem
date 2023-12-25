using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RAM;

public class RamBuilder : IRamBuilder
{
    private string? _name;
    private string? _formFactor;
    private string? _ddrStandardVersion;
    private List<string>? _supportedProfiles;
    private int _memorySize;
    private double _powerConsumption;
    private double _frequency;
    private double _voltage;

    public IRamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRamBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder WithDdrStandardVersion(string ddrStandardVersion)
    {
        _ddrStandardVersion = ddrStandardVersion;
        return this;
    }

    public IRamBuilder WithSupportedXmpAndDocProfiles(IEnumerable<string> supportedProfiles)
    {
        _supportedProfiles = supportedProfiles.ToList();
        return this;
    }

    public IRamBuilder WithAvailableMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRamBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRamBuilder WithSupportedJedecFrequencyAndVoltage(double frequency, double voltage)
    {
        _frequency = frequency;
        _voltage = voltage;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _name ?? throw new InvalidOperationException(),
            _formFactor ?? throw new InvalidOperationException(),
            _ddrStandardVersion ?? throw new InvalidOperationException(),
            _supportedProfiles ?? throw new InvalidOperationException(),
            _memorySize,
            _powerConsumption,
            _frequency,
            _voltage);
    }
}