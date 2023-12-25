using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Comments;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class ConsumingEnergyValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.CPU.PowerConsumption < Constants.TooMuchConsumingEnergy)
        {
            return new SuccessBuilding();
        }

        return new SuccessBuilding(new DisclaimerOfWarranties().Comment);
    }
}