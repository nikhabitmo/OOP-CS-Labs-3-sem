namespace Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;

public record ATXFormFactor(string Name = "ATX") : MotherBoardFormFactor(Name);