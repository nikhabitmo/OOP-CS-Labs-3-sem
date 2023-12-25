using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.WiFiAdapter;

public class DataBase
{
    public ICollection<Entities.WiFiAdapter> WiFiAdapters { get; private set; } = new List<Entities.WiFiAdapter>()
    {
        new Entities.WiFiAdapter("StandartWiFiAdapter", "2", true, "897f", 2),
        new Entities.WiFiAdapter("StandartWiFiAdapter2", "2", false, "897f", 3),
        new Entities.WiFiAdapter("StandartWiFiAdapter3", "2", true, "897s", 4),
        new Entities.WiFiAdapter("StandartWiFiAdapter4", "2", false, "897f", 3),
        new Entities.WiFiAdapter("StandartWiFiAdapter5", "1", false, "897d", 2),
        new Entities.WiFiAdapter("StandartWiFiAdapter6", "3", true, "897s", 4),
        new Entities.WiFiAdapter("StandartWiFiAdapter7", "4", true, "897d", 3),
    };
}