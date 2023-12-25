namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record BiosDoesntSupportCpuError : ErrorWhileBuilding
{
    public new string? Commentary { get; } = "Bios does not support CPU";
}