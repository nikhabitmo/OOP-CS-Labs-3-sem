namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record CpuDoesntSupportSocketError() : ErrorWhileBuilding
{
    public new string Commentary { get; } = "Cpu does not support socket";
}