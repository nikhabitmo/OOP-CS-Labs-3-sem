namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PC;
public interface IPCBuilder
{
    IPCBuilder WithCpu(string cpuName);
    IPCBuilder WithMotherBoard(string motherBoardName);
    IPCBuilder WithRam(string ramName);
    IPCBuilder WithFrame(string frameName);
    IPCBuilder WithDrive(string driveName);
    IPCBuilder WithSecondDrive(string secondDriveName);
    IPCBuilder WithVideoCard(string videoCardName);
    IPCBuilder WithPowerUnit(string powerUnitName);
    IPCBuilder WithWiFiAdapter(string wifiAdapterName);
    Entities.PC Build();
}
