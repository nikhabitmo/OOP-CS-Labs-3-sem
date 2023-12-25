namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Specification
{
    public Specification()
    {
    }

    public Specification(
        string powerUnitName,
        string frameName,
        string motherBoardName,
        string cpuName,
        string ramName,
        string driveName,
        string? secondDriveName,
        string? wiFiAdapterName,
        string? videoCardName)
    {
        CpuName = cpuName;
        MotherBoardName = motherBoardName;
        RamName = ramName;
        DriveName = driveName;
        SecondDriveName = secondDriveName;
        PowerUnitName = powerUnitName;
        FrameName = frameName;
        WiFiAdapterName = wiFiAdapterName;
        VideoCardName = videoCardName;
    }

    public string CpuName { get; private set; } = string.Empty;

    public string MotherBoardName { get; private set; } = string.Empty;

    public string RamName { get; private set; } = string.Empty;

    public string DriveName { get; private set; } = string.Empty;

    public string? SecondDriveName { get; private set; }

    public string PowerUnitName { get; private set; } = string.Empty;

    public string FrameName { get; private set; } = string.Empty;

    public string? WiFiAdapterName { get; private set; } = string.Empty;

    public string? VideoCardName { get; private set; } = string.Empty;
}