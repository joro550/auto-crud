using AutoCrud.Interfaces;
using AutoCrud.Interfaces.Models;
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


public sealed class CsvPersistenceComponentConfig : ComponentHeader
{
    public CsvPersistenceSpecificationConfig Spec { get; set; } = new();
}

public sealed class CsvPersistenceSpecificationConfig : PersistenceSpecification
{
    public CsvPersistenceMetadata Metadata { get; set; } = new();
}

public sealed class CsvPersistenceMetadata
{
    public string FileName { get; set; } = string.Empty;
    public string Separator { get; set; } = string.Empty;
}