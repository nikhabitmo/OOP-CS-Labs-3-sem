using System;

using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class SocketValidator : IPCValidator
{
    public BuildingPCResult Validate(Entities.PC pc)
    {
        if (pc == null) throw new ArgumentNullException(nameof(pc));

        if (pc.CPU.SupportedSocket == pc.MotherBoard.SupportedSocket) return new CpuDoesntSupportSocketError();

        return new SuccessBuilding();
    }
}