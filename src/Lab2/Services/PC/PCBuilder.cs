using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PC;

public class PCBuilder : IPCBuilder
{
    private ComputerDetailsAbstractFactory _computerDetailsAbstractFactory;

    private CollectionBuildingValidators _collectionBuildingValidators;

    public PCBuilder(
        Specification specification,
        ComputerDetailsAbstractFactory? computerDetailsAbstractFactory = null,
        CollectionBuildingValidators? collectionBuildingValidators = null)
    {
        _collectionBuildingValidators = collectionBuildingValidators ?? new CollectionBuildingValidators();

        _computerDetailsAbstractFactory = computerDetailsAbstractFactory ?? new ComputerDetailsAbstractFactory(
            new Factory<Entities.MotherBoard>(new DataBase.DataBase().MotherBoards),
            new Factory<Cpu>(new DataBase.DataBase().CPUs),
            new Factory<Ram>(new DataBase.DataBase().Rams),
            new Factory<Entities.WiFiAdapter>(new DataBase.DataBase().WiFiAdapters),
            new Factory<Frame>(new DataBase.DataBase().Frames),
            new Factory<BasicDrive>(new DataBase.DataBase().Drives),
            new Factory<Entities.VideoCard>(new DataBase.DataBase().VideoCards),
            new Factory<PowerUnit>(new DataBase.DataBase().PowerUnits));

        specification = specification ?? throw new ArgumentNullException(nameof(specification));

        PowerUnit =
            _computerDetailsAbstractFactory.CreatePowerUnit(specification.PowerUnitName) ??
            throw new InvalidOperationException();

        MotherBoard =
            _computerDetailsAbstractFactory.CreateMotherBoard(specification.MotherBoardName) ??
            throw new InvalidOperationException();

        CPU =
            _computerDetailsAbstractFactory.CreateCpu(specification.CpuName) ??
            throw new InvalidOperationException();

        RAM =
            _computerDetailsAbstractFactory.CreateRam(specification.RamName) ??
            throw new InvalidOperationException();

        Frame =
            _computerDetailsAbstractFactory.CreateFrame(specification.FrameName) ??
            throw new InvalidOperationException();

        Drive =
            _computerDetailsAbstractFactory.CreateDrive(specification.DriveName) ??
            throw new InvalidOperationException();

        if (specification.SecondDriveName != null)
            SecondDrive = _computerDetailsAbstractFactory.CreateDrive(specification.SecondDriveName);

        if (specification.VideoCardName != null)
            VideoCard = _computerDetailsAbstractFactory.CreateVideoCard(specification.VideoCardName);

        if (specification.WiFiAdapterName != null)
        {
            WiFiAdapter =
                _computerDetailsAbstractFactory
                    .CreateWiFiAdapter(
                        specification
                            .WiFiAdapterName) ?? throw new InvalidOperationException();
        }
    }

    public PCBuilder(
        Entities.PC pc,
        ComputerDetailsAbstractFactory? computerDetailsAbstractFactory = null,
        CollectionBuildingValidators? collectionBuildingValidators = null)
    {
        if (pc == null) throw new ArgumentNullException(nameof(pc));

        _collectionBuildingValidators = collectionBuildingValidators ?? new CollectionBuildingValidators();

        _computerDetailsAbstractFactory = computerDetailsAbstractFactory ?? new ComputerDetailsAbstractFactory(
            new Factory<Entities.MotherBoard>(new DataBase.DataBase().MotherBoards),
            new Factory<Cpu>(new DataBase.DataBase().CPUs),
            new Factory<Ram>(new DataBase.DataBase().Rams),
            new Factory<Entities.WiFiAdapter>(new DataBase.DataBase().WiFiAdapters),
            new Factory<Frame>(new DataBase.DataBase().Frames),
            new Factory<BasicDrive>(new DataBase.DataBase().Drives),
            new Factory<Entities.VideoCard>(new DataBase.DataBase().VideoCards),
            new Factory<PowerUnit>(new DataBase.DataBase().PowerUnits));

        Frame = pc.Frame;
        PowerUnit = pc.PowerUnit;
        CPU = pc.CPU;
        MotherBoard = pc.MotherBoard;
        RAM = pc.RAM;
        Drive = pc.Drive;
        SecondDrive = pc.SecondDrive;
        VideoCard = pc.VideoCard;
        WiFiAdapter = pc.WiFiAdapter;
    }

    public BuildingPCResult BuildingPcResult { get; private set; } = new SuccessBuilding();

    public IList<string> Comments { get; private set; } = new List<string>();
    private Cpu CPU { get; set; }

    private Entities.MotherBoard MotherBoard { get; set; }

    private Ram RAM { get; set; }

    private Frame Frame { get; set; }

    private BasicDrive Drive { get; set; }

    private BasicDrive? SecondDrive { get; set; }

    private Entities.VideoCard? VideoCard { get; set; }

    private Entities.PowerUnit PowerUnit { get; set; }

    private Entities.WiFiAdapter? WiFiAdapter { get; set; }

    public IPCBuilder WithCpu(string cpuName)
    {
        CPU = _computerDetailsAbstractFactory.CreateCpu(cpuName) ?? throw new InvalidOperationException();
        return this;
    }

    public IPCBuilder WithMotherBoard(string motherBoardName)
    {
        MotherBoard = _computerDetailsAbstractFactory.CreateMotherBoard(motherBoardName) ??
                      throw new InvalidOperationException();
        return this;
    }

    public IPCBuilder WithRam(string ramName)
    {
        RAM = _computerDetailsAbstractFactory.CreateRam(ramName) ?? throw new InvalidOperationException();
        return this;
    }

    public IPCBuilder WithFrame(string frameName)
    {
        Frame = _computerDetailsAbstractFactory.CreateFrame(frameName) ?? throw new InvalidOperationException();
        return this;
    }

    public IPCBuilder WithDrive(string driveName)
    {
        Drive = _computerDetailsAbstractFactory.CreateDrive(driveName) ?? throw new InvalidOperationException();
        return this;
    }

    public IPCBuilder WithSecondDrive(string secondDriveName)
    {
        SecondDrive = _computerDetailsAbstractFactory.CreateDrive(secondDriveName);
        return this;
    }

    public IPCBuilder WithVideoCard(string videoCardName)
    {
        VideoCard = _computerDetailsAbstractFactory.CreateVideoCard(videoCardName);
        return this;
    }

    public IPCBuilder WithPowerUnit(string powerUnitName)
    {
        PowerUnit = _computerDetailsAbstractFactory.CreatePowerUnit(powerUnitName)
                    ?? throw new InvalidOperationException();
        return this;
    }

    public IPCBuilder WithWiFiAdapter(string wifiAdapterName)
    {
        WiFiAdapter = _computerDetailsAbstractFactory.CreateWiFiAdapter(wifiAdapterName) ??
                      throw new InvalidOperationException();
        return this;
    }

    public Entities.PC Build()
    {
        var pc = new Entities.PC(
            PowerUnit,
            Frame,
            MotherBoard,
            CPU,
            RAM,
            Drive,
            SecondDrive,
            VideoCard,
            WiFiAdapter);

        foreach (IPCValidator validator in _collectionBuildingValidators.BuildingValidators)
        {
            BuildingPcResult = validator.Validate(pc);

            if (BuildingPcResult is ErrorWhileBuilding)
            {
                if (BuildingPcResult.Commentary != null) Comments.Add(BuildingPcResult.Commentary);
                break;
            }

            if (BuildingPcResult is SuccessBuilding && BuildingPcResult.Commentary != null)
            {
                Comments.Add(BuildingPcResult.Commentary);
            }
        }

        return pc;
    }
}