using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DdrStandart;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Bios;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MotherBoard;

public class MotherboardBuilder : IMotherBoardBuilder
{
    private string? _name;
    private Socket? _supportedSocket;
    private int _numberOfPcieLines;
    private int _numberOfSataPorts;
    private string? _chipSet;
    private int _numberOfRamSlots;
    private IDdrStandart? _ddrStandard;
    private MotherBoardFormFactor? _motherboardFormFactor;
    private Models.Bios _bios = new Models.Bios();
    private Xmp? _xmp = new Xmp();

    public IMotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoardBuilder WithSupportedSocket(Socket socket)
    {
        _supportedSocket = socket;
        return this;
    }

    public IMotherBoardBuilder WithNumberOfPcieLines(int numberOfPcieLines)
    {
        _numberOfPcieLines = numberOfPcieLines;
        return this;
    }

    public IMotherBoardBuilder WithNumberOfSataPorts(int numberOfSataPorts)
    {
        _numberOfSataPorts = numberOfSataPorts;
        return this;
    }

    public IMotherBoardBuilder WithChipSet(string chipSet)
    {
        _chipSet = chipSet;
        return this;
    }

    public IMotherBoardBuilder WithDdrStandard(IDdrStandart ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherBoardBuilder WithNumberOfRamSlots(int numberOfRamSlots)
    {
        _numberOfRamSlots = numberOfRamSlots;
        return this;
    }

    public IMotherBoardBuilder WithMotherboardFormFactor(MotherBoardFormFactor motherboardFormFactor)
    {
        _motherboardFormFactor = motherboardFormFactor;
        return this;
    }

    public IMotherBoardBuilder WithBios(IBiosBuilder? bios)
    {
        if (bios != null) _bios = bios.Build();
        return this;
    }

    public IMotherBoardBuilder WithXmp(Xmp? xmp)
    {
        _xmp = xmp;
        return this;
    }

    public Entities.MotherBoard Build()
    {
        return new Entities.MotherBoard(
            _name ?? throw new InvalidOperationException(),
            _supportedSocket ?? throw new InvalidOperationException(),
            _numberOfPcieLines,
            _numberOfSataPorts,
            _chipSet,
            _ddrStandard,
            _numberOfRamSlots,
            _motherboardFormFactor,
            _bios,
            _xmp);
    }
}