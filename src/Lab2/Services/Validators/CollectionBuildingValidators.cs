using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CollectionBuildingValidators
{
    public CollectionBuildingValidators()
    {
        BuildingValidators = new List<IPCValidator>();
        BuildingValidators.Add(new PowerUnitValidator());
        BuildingValidators.Add(new SocketValidator());
        BuildingValidators.Add(new BiosValidator());
        BuildingValidators.Add(new ConsumingEnergyValidator());
        BuildingValidators.Add(new RamValidator());
        BuildingValidators.Add(new FrameValidator());
        BuildingValidators.Add(new CpuCoolingSystemValidator());
    }

    public ICollection<IPCValidator> BuildingValidators { get; }
}