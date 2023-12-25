using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Storage;

public class ChipSets
{
    public ICollection<string> AvailableChipsets { get; } = new List<string>();

    public void AddChipset(string chipSet)
    {
        AvailableChipsets.Add(chipSet);
    }

    public string? FindChipSetByName(string chipSetName)
    {
        return AvailableChipsets.FirstOrDefault(chipSet => chipSetName == chipSet);
    }
}
