using AutoCrud.Interfaces;
using LanguageExt;

namespace AutoCrud.Logic;

public sealed class Component
{
    private readonly Dictionary<string, IPersistence> _stores;

    public Component(Dictionary<string,IPersistence> stores) => _stores = stores;

    public Option<IPersistence> GetStore(string name) 
        => _stores.TryGetValue(name, out var value) ? Prelude.Some(value) : Prelude.None;
}

