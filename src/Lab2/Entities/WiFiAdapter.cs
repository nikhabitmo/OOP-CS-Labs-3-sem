using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : IComponent
{
    public WiFiAdapter(string name, string versionWiFi, bool doesHaveBluetoothModule, string versionPcie, int powerConsumption)
    {
        Name = name;
        VersionWiFi = versionWiFi;
        DoesHaveBluetoothModule = doesHaveBluetoothModule;
        VersionPcie = versionPcie;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public string VersionWiFi { get; private set; }
    public string VersionPcie { get; private set; }
    public bool DoesHaveBluetoothModule { get; private set; }
    public int PowerConsumption { get; private set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(
            Name,
            VersionWiFi,
            DoesHaveBluetoothModule,
            VersionPcie,
            PowerConsumption);
    }
}