using Itmo.ObjectOrientedProgramming.Lab2.Models.ConnectionType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;

public class HDD : BasicDrive
{
    public HDD(string name, Connection connectionOption, int capacity, int powerConsumption)
        : base(name, connectionOption, capacity, powerConsumption)
    {
    }

    public override BasicDrive Clone()
    {
        return new HDD(Name, ConnectionOption, Capacity, PowerConsumption);
    }
}