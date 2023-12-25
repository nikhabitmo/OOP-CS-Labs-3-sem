namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record CpuDoesntSupportCoolingSystem() : ErrorWhileBuilding
{
    public new string? Commentary { get; } = "Cpu does not support cooling system";
}