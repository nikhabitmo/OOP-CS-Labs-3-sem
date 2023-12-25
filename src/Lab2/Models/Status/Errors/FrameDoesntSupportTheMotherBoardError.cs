namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;

public record FrameDoesntSupportTheMotherBoardError : ErrorWhileBuilding
{
    public new string Commentary { get; } = "Frame doesn't support the MotherBoard";
}