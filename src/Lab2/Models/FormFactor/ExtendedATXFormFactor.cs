namespace Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;

public record ExtendedATXFormFactor(string Name = "EATX") : MotherBoardFormFactor(Name);