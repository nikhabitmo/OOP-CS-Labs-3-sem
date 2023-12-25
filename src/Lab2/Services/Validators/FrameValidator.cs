using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class FrameValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        pc = pc ?? throw new ArgumentNullException(nameof(pc));

        if (pc.Frame.SupportedMotherboardFormFactors.Contains(nameof(pc.MotherBoard.MotherboardFormFactor)))
        {
            return new SuccessBuilding();
        }

        if (
            pc.CPU.CoolingSystem.Dimensions.Width <= pc.Frame.MaximumWidth &&
            pc.CPU.CoolingSystem.Dimensions.Length <= pc.Frame.MaximumLength)
        {
            return new SuccessBuilding();
        }

        return new FrameDoesntSupportTheMotherBoardError();
    }
}