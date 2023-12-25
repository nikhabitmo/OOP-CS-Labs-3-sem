using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Factory<T> : IFactory<T>
where T : IComponent
{
    public Factory()
    {
        ComponentsList = new Collection<T>();
    }

    public Factory(ICollection<T> collection)
    {
        ComponentsList = collection;
    }

    public ICollection<T> ComponentsList { get; }

    public void AddComponent(T component)
    {
        ComponentsList.Add(component);
    }

    public T? GetByName(string name)
    {
        return ComponentsList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}