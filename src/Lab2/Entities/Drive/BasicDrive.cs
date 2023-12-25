using Itmo.ObjectOrientedProgramming.Lab2.Models.ConnectionType;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;

public abstract class BasicDrive : IComponent
{
    protected BasicDrive(string name, Connection connectionOption, int capacity, int powerConsumption)
    {
        Name = name;
        ConnectionOption = connectionOption;
        Capacity = capacity;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public Connection ConnectionOption { get; private set; }
    public int Capacity { get; private set; }
    public int PowerConsumption { get; private set; }
    public abstract BasicDrive Clone();
}