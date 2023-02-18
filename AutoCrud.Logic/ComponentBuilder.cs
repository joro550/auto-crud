using AutoCrud.Interfaces;

namespace AutoCrud.Logic;

internal class ComponentBuilder
{
    private readonly Dictionary<string, IPersistence> _stores = new();

    public ComponentBuilder AddStore(string name, IPersistence persistence)
    {
        _stores.Add(name, persistence);
        return this;
    }

    public Component Build() => new(_stores);
}