using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Services.PC;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Configurator
{
    public Configurator()
    {
    }

    public IList<string> Commentaries { get; private set; } = new List<string>();
    public BuildingPCResult Validate(Specification specification)
    {
        var pcBuilder = new PCBuilder(specification);
        pcBuilder.Build();
        Commentaries = pcBuilder.Comments;

        return pcBuilder.BuildingPcResult;
    }

    public BuildingPCResult Validate(Entities.PC pc)
    {
        var pcBuilder = new PCBuilder(pc);
        pcBuilder.Build();
        Commentaries = pcBuilder.Comments;

        return pcBuilder.BuildingPcResult;
    }
}