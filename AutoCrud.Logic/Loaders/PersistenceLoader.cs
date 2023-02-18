using CsvPersistence;
using AutoCrud.Interfaces;
using AutoCrud.Interfaces.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AutoCrud.Logic.Loaders;

public static class PersistenceLoader
{
    private static readonly List<IPersistenceLoader> Loaders = new()
    {
        new CsvPersistenceLoader()
    };
    
    public static IPersistence GetPersistenceStore(string fileContent)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        var component = deserializer.Deserialize<PersistenceComponent>(fileContent);
        foreach (var componentHandler in Loaders.Where(x => x.CanHandle(component.Spec.Type)))
        {
            return componentHandler.Load(fileContent);
        }
        
        return new NullPersistence();
    }
}