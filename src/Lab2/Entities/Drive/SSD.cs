using Itmo.ObjectOrientedProgramming.Lab2.Models.ConnectionType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;

public class SSD : BasicDrive
{
    public SSD(string name, Connection connectionOption, int capacity, int powerConsumption, int maximumOperatingSpeed)
        : base(name, connectionOption, capacity, powerConsumption)
    {
        MaximumOperatingSpeed = maximumOperatingSpeed;
    }

    public int MaximumOperatingSpeed { get; private set; }
    public override BasicDrive Clone()
    {
        return new SSD(Name, ConnectionOption, Capacity, PowerConsumption, MaximumOperatingSpeed);
    }
}