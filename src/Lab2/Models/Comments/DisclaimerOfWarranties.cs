namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Comments;

public record DisclaimerOfWarranties(string? Name = null)
{
    public string Comment { get; private set; } = Name ?? "Disclaimer of warranties";
}