using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class RamValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.MotherBoard.NumberOfRamSlots > 0 || pc.MotherBoard.MotherboardFormFactor?.Name == pc.RAM.FormFactor)
        {
            return new SuccessBuilding();
        }

        return new RamDoesntSupportedError();
    }
}