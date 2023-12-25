using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Comments;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PowerUnitValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.PowerUnit.PeakLoad <= Constants.NotEnoughPowerUnit)
        {
            return new SuccessBuilding(new PowerUnitCapacitiesAreNotObserved().Comment);
        }

        return new SuccessBuilding();
    }
}