using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Bios;

public class BiosBuilder : IBiosBuilder
{
    private string _type;

    private string _version;

    private List<string> _supportableCpuNames;
    public BiosBuilder()
    {
        _type = string.Empty;
        _version = string.Empty;
        _supportableCpuNames = new List<string>();
    }

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportableCpus(params string[] cpuNames)
    {
        _supportableCpuNames.AddRange(cpuNames);
        return this;
    }

    public Models.Bios Build()
    {
        var bios = new Models.Bios(_type, _version);
        bios.AddSupportableCpus(_supportableCpuNames.ToArray());
        return bios;
    }
}