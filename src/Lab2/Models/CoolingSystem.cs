using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class CoolingSystem
{
    public CoolingSystem(string? name, Dimension dimensions, int maximumHeatdissipationMass)
    {
        Name = name;
        Dimensions = dimensions;
        MaximumHeatdissipationMass = maximumHeatdissipationMass;
    }

    public string? Name { get; private set; }

    public Dimension Dimensions { get; private set; }

    public IList<Socket> SupportedSockets { get; private set; } = new List<Socket>();

    public int MaximumHeatdissipationMass { get; private set; }

    public CoolingSystem AddSupportedSocket(Socket socket)
    {
        SupportedSockets.Add(socket);
        return this;
    }

    public CoolingSystem Clone()
    {
        return new CoolingSystem(Name, Dimensions, MaximumHeatdissipationMass);
    }
}