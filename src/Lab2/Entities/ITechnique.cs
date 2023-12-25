namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ITechnique
{
    Specification GetSpecification();
    ITechnique Clone();
}