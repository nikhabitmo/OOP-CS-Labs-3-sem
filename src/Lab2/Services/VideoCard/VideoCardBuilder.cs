namespace Itmo.ObjectOrientedProgramming.Lab2.Services.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private string _name = string.Empty;
    private int _height;
    private int _width;
    private int _videoMemorySize;
    private string _pciExpressVersion = string.Empty;
    private int _chipFrequency;
    private int _powerConsumption;

    public IVideoCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IVideoCardBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public IVideoCardBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public IVideoCardBuilder WithVideoMemorySize(int videoMemorySize)
    {
        _videoMemorySize = videoMemorySize;
        return this;
    }

    public IVideoCardBuilder WithPciExpressVersion(string pciExpressVersion)
    {
        _pciExpressVersion = pciExpressVersion;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Entities.VideoCard Build()
    {
        return new Entities.VideoCard(
            _name,
            _height,
            _width,
            _videoMemorySize,
            _pciExpressVersion,
            _chipFrequency,
            _powerConsumption);
    }
}