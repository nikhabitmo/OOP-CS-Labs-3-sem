using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class BiosValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.MotherBoard.Bios.SupportableCpuNames.Contains(pc.CPU.Name)) return new BiosDoesntSupportCpuError();

        return new SuccessBuilding();
    }
}