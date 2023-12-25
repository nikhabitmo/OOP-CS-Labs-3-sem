using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Comments;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Result.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.PC;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Fact]
    public void TestAllComponentsSuit()
    {
        var configurator = new Configurator();
        var specification = new Specification(
            "PowerUnit1",
            "Standart Frame",
            "motherboard1",
            "MidRangeCPU",
            "Kingston HyperX 8GB",
            "SSD1",
            null,
            "StandartWiFiAdapter",
            "VideoCard1");
        BuildingPCResult result = configurator.Validate(specification);
        Assert.Equal(new SuccessBuilding(), result);
    }

    [Fact]
    public void TestDisclaimerOfWarranties()
    {
        var configurator = new Configurator();
        var specification = new Specification(
            "PowerUnit2",
            "HighPerformanceFrame",
            "motherboard2",
            "HighPerformanceCPU",
            "Kingston HyperX 8GB",
            "SSD2",
            null,
            null,
            "HighPerformanceVideoCard");
        BuildingPCResult result = configurator.Validate(specification);
        Assert.Equal(new SuccessBuilding(), result);
        Assert.Equal(new DisclaimerOfWarranties().Comment, configurator.Commentaries[0]);
    }

    [Fact]
    public void TestChangeComponent()
    {
        var configurator = new Configurator();
        var specification = new Specification(
            "PowerUnit1",
            "Standart Frame",
            "motherboard2",
            "MidRangeCPU",
            "Kingston HyperX 8GB",
            "SSD1",
            null,
            "StandartWiFiAdapter",
            "VideoCard1");
        BuildingPCResult result = configurator.Validate(specification);
        Assert.Equal(new SuccessBuilding(), result);

        IPCBuilder pcBuilder = new PCBuilder(specification).WithMotherBoard("motherboard1");
        PC pc = pcBuilder.Build();
        BuildingPCResult newResult = configurator.Validate(pc);
        Assert.Equal(new SuccessBuilding(), newResult);
    }

    [Fact]
    public void TestWrongComponents()
    {
        var configurator = new Configurator();
        var specification = new Specification(
            "PowerUnit1",
            "Compact Frame",
            "motherboard2",
            "BudgetCPU",
            "Kingston HyperX 8GB",
            "SSD2",
            null,
            "StandartWiFiAdapter",
            "VideoCard1");
        BuildingPCResult result = configurator.Validate(specification);
        Assert.Equal(new PowerUnitCapacitiesAreNotObserved().Comment, configurator.Commentaries[0]);
        Assert.Equal(new DisclaimerOfWarranties().Comment, configurator.Commentaries[1]);
        Assert.IsType<FrameDoesntSupportTheMotherBoardError>(result);
    }
}