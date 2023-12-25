namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IFactory<out T>
{
    T? GetByName(string name);
}