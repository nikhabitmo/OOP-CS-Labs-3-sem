using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Status;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    [Fact]
    public void TestRouteWithAvgurInIncreasedDensityNebulaShouldFail()
    {
        var environments = new List<EnvironmentBase>
        {
            new IncreasedDensityNebula(),
        };

        var route = new Route(environments);

        SpaceShipBase pleasureShuttle = new PleasureShuttle();
        SpaceShipBase avgur = new Avgur();

        ShipTravelResult result1 = route.PassRoute(pleasureShuttle);
        ShipTravelResult result2 = route.PassRoute(avgur);

        Assert.Equal(ShipTravelResult.Lost, result1);
        Assert.Equal(ShipTravelResult.Lost, result2);
    }

    [Fact]

    public void TestRouteWithVaklasInParticleNitrineNebula()
    {
        var environments = new List<EnvironmentBase>
        {
            new IncreasedDensityNebula(1),
        };

        var route = new Route(environments);

        SpaceShipBase vaklasBasic = new Vaklas();
        SpaceShipBase vaklasWithPhotonicDeflector = new Vaklas(new Photonic());

        ShipTravelResult result1 = route.PassRoute(vaklasBasic);
        ShipTravelResult result2 = route.PassRoute(vaklasWithPhotonicDeflector);

        Assert.Equal(ShipTravelResult.Crushed, result1);
        Assert.Equal(ShipTravelResult.Success, result2);
    }

    [Fact]

    public void TestRouteWithCosmoKits()
    {
        var environments = new List<EnvironmentBase>
        {
            new ParticleNitrineNebula(1),
        };

        var route = new Route(environments);

        SpaceShipBase vaklas = new Vaklas();
        SpaceShipBase avgur = new Avgur();
        SpaceShipBase meridian = new Meridian();

        ShipTravelResult result1 = route.PassRoute(vaklas);
        ShipTravelResult result2 = route.PassRoute(avgur);
        ShipTravelResult result3 = route.PassRoute(meridian);

        Assert.Equal(ShipTravelResult.Crushed, result1);
        Assert.Equal(ShipTravelResult.Success, result2);
        Assert.Equal(ShipTravelResult.Success, result3);
    }

    [Fact]
    public void SimulationRouteSpace()
    {
        var environments = new List<EnvironmentBase>
        {
            new Space(),
        };

        var route = new Route(environments);

        SpaceShipBase pleasureShuttle = new PleasureShuttle();
        SpaceShipBase vaklas = new Vaklas();

        var simulation = new Simulation(route, pleasureShuttle, vaklas);
        SpaceShipBase mostBenefitShip = simulation.GetMostBenefitShip();

        Assert.Equal(pleasureShuttle, mostBenefitShip);
    }

    [Fact]
    public void SimulationRouteIncreasedDensityNebula()
    {
        var environments = new List<EnvironmentBase>
        {
            new IncreasedDensityNebula(),
        };

        var route = new Route(environments);

        SpaceShipBase stella = new Stella();
        SpaceShipBase avgur = new Avgur();

        var simulation = new Simulation(route, stella, avgur);
        SpaceShipBase mostBenefitShip = simulation.GetMostBenefitShip();

        Assert.Equal(stella, mostBenefitShip);
    }

    [Fact]
    public void SimulationRouteParticleNitrineNebula()
    {
        var environments = new List<EnvironmentBase>
        {
            new IncreasedDensityNebula(),
        };

        var route = new Route(environments);

        SpaceShipBase vaklas = new Vaklas();
        SpaceShipBase pleasureShuttle = new PleasureShuttle();

        var simulation = new Simulation(route, pleasureShuttle, vaklas);
        SpaceShipBase mostBenefitShip = simulation.GetMostBenefitShip();

        Assert.Equal(vaklas, mostBenefitShip);
    }

    [Fact]
    public void RouteWithSeveralEnvironments()
    {
        var environments = new List<EnvironmentBase>
        {
            new Space(1, 2),
            new IncreasedDensityNebula(),
        };

        var route = new Route(environments);

        SpaceShipBase vaklas = new Vaklas();
        SpaceShipBase pleasureShuttle = new PleasureShuttle();
        SpaceShipBase avgur = new Avgur();

        var simulation = new Simulation(route, pleasureShuttle, vaklas, avgur);
        SpaceShipBase mostBenefitShip = simulation.GetMostBenefitShip();

        Assert.Equal(vaklas, mostBenefitShip);
    }

    [Fact]
    public void RouteWithAllEnvironments()
    {
        var environments = new List<EnvironmentBase>
        {
            new Space(1, 2),
            new IncreasedDensityNebula(),
            new ParticleNitrineNebula(1),
        };

        var route = new Route(environments);
        var simulation = new Simulation(route);
        SpaceShipBase mostBenefitShip = simulation.GetMostBenefitShip();

        Assert.IsType<Meridian>(mostBenefitShip);
    }
}