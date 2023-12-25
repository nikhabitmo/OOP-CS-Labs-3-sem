using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.WiFiAdapter;

public class WiFIFactory : IFactory<Entities.WiFiAdapter>
{
    public WiFIFactory()
    {
        WiFiAdapters.Add(new Entities.WiFiAdapter("StandartWiFiAdapter", "2", true, "897f", 2));
        WiFiAdapters.Add(new Entities.WiFiAdapter("a", "2", true, "897f", 2));
        WiFiAdapters.Add(new Entities.WiFiAdapter("a", "2", true, "897f", 2));
        WiFiAdapters.Add(new Entities.WiFiAdapter("a", "2", true, "897f", 2));
        WiFiAdapters.Add(new Entities.WiFiAdapter("a", "2", true, "897f", 2));
        WiFiAdapters.Add(new Entities.WiFiAdapter("a", "2", true, "897f", 2));
        WiFiAdapters.Add(new Entities.WiFiAdapter("a", "2", true, "897f", 2));
    }

    public ICollection<Entities.WiFiAdapter> WiFiAdapters { get; private set; } = new Collection<Entities.WiFiAdapter>();
    public Entities.WiFiAdapter? GetByName(string name)
    {
        return WiFiAdapters.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}