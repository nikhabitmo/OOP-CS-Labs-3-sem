using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerDetailsAbstractFactory
{
    public Entities.MotherBoard? CreateMotherBoard(string name);
    public Cpu? CreateCpu(string name);
    public Ram? CreateRam(string name);
    public Entities.WiFiAdapter? CreateWiFiAdapter(string name);
    public BasicDrive? CreateDrive(string name);
    public Frame? CreateFrame(string name);
    public Entities.VideoCard? CreateVideoCard(string name);
    public Entities.PowerUnit? CreatePowerUnit(string name);
}