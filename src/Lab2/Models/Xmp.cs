namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Xmp
{
    public Xmp()
    {
    }

    public Xmp(string? timing, string? voltage, int frequency)
    {
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string? Timing { get; private set; }
    public string? Voltage { get; private set; }
    public int Frequency { get; private set; }
}