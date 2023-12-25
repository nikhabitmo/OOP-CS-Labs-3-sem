using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CPU;

public class CpuBuilder : ICpuBuilder
{
    private string _name = string.Empty;
    private Socket? _socket;
    private int _coreFrequency;
    private bool _hasBuiltInVideoCore;
    private int _supportedMemoryFrequencies;
    private int _heatDissipation;
    private int _powerConsumption;
    private CoolingSystem? _coolingSystem;

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithSupportedSocket(Socket? socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithBuiltInVideoCore(bool hasBuiltInVideoCore)
    {
        _hasBuiltInVideoCore = hasBuiltInVideoCore;
        return this;
    }

    public ICpuBuilder WithSupportedMemoryFrequencies(int supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public ICpuBuilder WithHeatDissipation(int heatDissipation)
    {
        _heatDissipation = heatDissipation;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpuBuilder WithCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name,
            _socket ?? throw new InvalidOperationException(),
            _coreFrequency,
            _hasBuiltInVideoCore,
            _supportedMemoryFrequencies,
            _heatDissipation,
            _powerConsumption,
            _coolingSystem ?? throw new InvalidOperationException());
    }
}