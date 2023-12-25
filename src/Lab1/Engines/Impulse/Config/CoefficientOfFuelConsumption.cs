using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Config;

public static class CoefficientOfFuelConsumption
{
    public static double Base => 1;
    public static double C => 1;
    public static double E => Math.E * double.Log10(Math.E);
}