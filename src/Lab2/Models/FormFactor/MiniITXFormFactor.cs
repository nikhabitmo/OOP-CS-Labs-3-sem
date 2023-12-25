namespace Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;

public record MiniITXFormFactor(string Name = "ITX") : MotherBoardFormFactor(Name);