using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var environments = new List<EnvironmentBase>
        {
            new ParticleNitrineNebula(1),
        };

        var route = new Route(environments);

        SpaceShipBase pleasureShuttle = new PleasureShuttle();
        SpaceShipBase vaklas = new Vaklas();

        var simulation = new Simulation(route, pleasureShuttle, vaklas);
        SpaceShipBase mostBenefitShip = simulation.GetMostBenefitShip();
        Console.WriteLine(mostBenefitShip);
    }
}
