using AutoCrud.Interfaces;
using CsvPersistence.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CsvPersistence;

public class CsvPersistenceLoader : IPersistenceLoader
{
    public bool CanHandle(string type)
    {
        return string.Compare(type, "csv", StringComparison.OrdinalIgnoreCase) == 0;
    }

    public IPersistence Load(string config)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();
        var fileConfig = deserializer.Deserialize<CsvPersistenceComponentConfig>(config);
        return new CsvPersistence(fileConfig.Spec.Metadata);
    }
}