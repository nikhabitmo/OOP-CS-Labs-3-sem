using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Comments;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CpuCoolingSystemValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.CPU.CoolingSystem.SupportedSockets.Contains(pc.CPU.SupportedSocket))
        {
            if (pc.CPU.HeatDissipation <= pc.CPU.CoolingSystem.MaximumHeatdissipationMass)
            {
                return new SuccessBuilding();
            }

            return new SuccessBuilding(new DisclaimerOfWarranties().Comment);
        }

        return new ErrorWhileBuilding();
    }
}