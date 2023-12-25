using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class VideoCard : IComponent
{
    public VideoCard(
        string name,
        int height,
        int width,
        int videoMemorySize,
        string pciExpressVersion,
        int chipFrequency,
        int powerConsumption)
    {
        Name = name;
        Height = height;
        Width = width;
        VideoMemorySize = videoMemorySize;
        PciExpressVersion = pciExpressVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public int Height { get; private set; }

    public int Width { get; private set; }

    public int VideoMemorySize { get; private set; }

    public string PciExpressVersion { get; private set; }

    public int ChipFrequency { get; private set; }

    public int PowerConsumption { get; private set; }

    public VideoCard Clone()
    {
        return new VideoCard(
            Name,
            Height,
            Width,
            VideoMemorySize,
            PciExpressVersion,
            ChipFrequency,
            PowerConsumption);
    }
}