namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record FrameDoesntSupportTheCpuCoolingSystemError() : ErrorWhileBuilding
{
    public new string Commentary { get; } = "Frame can't support the cpu's cooling system because of the size";
}
