using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Bios
{
    public Bios()
    { }
    public Bios(string? type, string? version)
    {
        Type = type;
        Version = version;
    }

    public string? Type { get; private set; }
    public string? Version { get; private set; }

    public ICollection<string> SupportableCpuNames { get; private set; } = new List<string>();

    public void AddSupportableCpus(params string[]? cpuNames)
    {
        if (cpuNames != null)
        {
            foreach (string cpuName in cpuNames)
            {
                SupportableCpuNames.Add(cpuName);
            }
        }
    }
}