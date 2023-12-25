using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public interface IPCValidator
{
    BuildingPCResult Validate(Entities.PC pc);
}