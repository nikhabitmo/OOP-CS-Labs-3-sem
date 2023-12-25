using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDetailsAbstractFactory : IComputerDetailsAbstractFactory
{
    private readonly IFactory<Entities.MotherBoard> _motherBoardFactory;

    private readonly IFactory<Cpu> _cpuFactory;

    private readonly IFactory<Ram> _ramFactory;

    private readonly IFactory<Entities.WiFiAdapter> _wifiModuleFactory;

    private readonly IFactory<Frame> _frameFactory;

    private readonly IFactory<BasicDrive> _driveFactory;

    private readonly IFactory<Entities.VideoCard> _videoCardFactory;

    private readonly IFactory<Entities.PowerUnit> _powerUnitFactory;

    public ComputerDetailsAbstractFactory(
        IFactory<Entities.MotherBoard> motherBoardFactory,
        IFactory<Cpu> cpuFactory,
        IFactory<Ram> ramFactory,
        IFactory<Entities.WiFiAdapter> wifiModuleFactory,
        IFactory<Frame> frameFactory,
        IFactory<BasicDrive> driveFactory,
        IFactory<Entities.VideoCard> videoCardFactory,
        IFactory<Entities.PowerUnit> powerUnitFactory)
    {
        _motherBoardFactory = motherBoardFactory;
        _cpuFactory = cpuFactory;
        _ramFactory = ramFactory;
        _wifiModuleFactory = wifiModuleFactory;
        _frameFactory = frameFactory;
        _driveFactory = driveFactory;
        _videoCardFactory = videoCardFactory;
        _powerUnitFactory = powerUnitFactory;
    }

    public Cpu? CreateCpu(string name)
    {
        return _cpuFactory.GetByName(name);
    }

    public Ram? CreateRam(string name)
    {
        return _ramFactory.GetByName(name);
    }

    public Entities.MotherBoard? CreateMotherBoard(string name)
    {
        return _motherBoardFactory.GetByName(name);
    }

    public Entities.WiFiAdapter? CreateWiFiAdapter(string name)
    {
        return _wifiModuleFactory.GetByName(name);
    }

    public BasicDrive? CreateDrive(string name)
    {
        return _driveFactory.GetByName(name);
    }

    public Frame? CreateFrame(string name)
    {
        return _frameFactory.GetByName(name);
    }

    public Entities.VideoCard? CreateVideoCard(string name)
    {
        return _videoCardFactory.GetByName(name);
    }

    public Entities.PowerUnit? CreatePowerUnit(string name)
    {
        return _powerUnitFactory.GetByName(name);
    }
}