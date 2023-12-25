namespace Itmo.ObjectOrientedProgramming.Lab2.Services.VideoCard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithName(string name);
    IVideoCardBuilder WithHeight(int height);
    IVideoCardBuilder WithWidth(int width);
    IVideoCardBuilder WithVideoMemorySize(int videoMemorySize);
    IVideoCardBuilder WithPciExpressVersion(string pciExpressVersion);
    IVideoCardBuilder WithChipFrequency(int chipFrequency);
    IVideoCardBuilder WithPowerConsumption(int powerConsumption);
    Entities.VideoCard Build();
}