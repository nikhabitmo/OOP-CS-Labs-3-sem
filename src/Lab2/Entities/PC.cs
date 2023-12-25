using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PC : ITechnique
{
    public PC(
        PowerUnit powerUnit,
        Frame frame,
        MotherBoard motherBoard,
        Cpu cpu,
        Ram ram,
        BasicDrive drive,
        BasicDrive? secondDrive,
        VideoCard? videoCard,
        WiFiAdapter? wiFiAdapter)
    {
        Frame = frame;
        CPU = cpu;
        MotherBoard = motherBoard;
        RAM = ram;
        Drive = drive;
        SecondDrive = secondDrive;
        VideoCard = videoCard;
        PowerUnit = powerUnit;
        WiFiAdapter = wiFiAdapter;
    }

    public Cpu CPU { get; private set; }
    public MotherBoard MotherBoard { get; private set; }
    public Ram RAM { get; private set; }
    public Frame Frame { get; private set; }
    public BasicDrive Drive { get; private set; }
    public BasicDrive? SecondDrive { get; private set; }
    public VideoCard? VideoCard { get; private set; }
    public PowerUnit PowerUnit { get; private set; }
    public WiFiAdapter? WiFiAdapter { get; private set; }

    public Specification GetSpecification()
    {
        return new Specification(
            PowerUnit.Name,
            Frame.Name,
            MotherBoard.Name,
            CPU.Name,
            RAM.Name,
            Drive.Name,
            SecondDrive?.Name,
            WiFiAdapter?.Name,
            VideoCard?.Name);
    }

    public ITechnique Clone()
    {
        return new PC(
            PowerUnit,
            Frame,
            MotherBoard,
            CPU,
            RAM,
            Drive,
            SecondDrive,
            VideoCard,
            WiFiAdapter);
    }
}