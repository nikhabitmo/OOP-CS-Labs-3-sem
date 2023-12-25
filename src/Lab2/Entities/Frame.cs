using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Frame : IComponent
{
    public Frame(string name, int maximumLength, int maximumWidth, int dimension)
    {
        Name = name;
        MaximumLength = maximumLength;
        MaximumWidth = maximumWidth;
        Dimension = dimension;
    }

    public string Name { get; set; }
    public int MaximumLength { get; private set; }
    public int MaximumWidth { get; private set; }
    public int Dimension { get; private set; }
    public ICollection<string> SupportedMotherboardFormFactors { get; private set; } = new Collection<string>();
    public Frame Clone()
    {
        return new Frame(Name, MaximumLength, MaximumWidth, Dimension);
    }
}