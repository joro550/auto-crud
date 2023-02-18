using AutoCrud.Interfaces;
using AutoCrud.Interfaces.Models;
using AutoCrud.Logic.Loaders;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AutoCrud.Logic;

public static class ComponentLoader
{
    public static async Task<Component> LoadComponents(List<string> fileList)
    {
        var builder = new ComponentBuilder();
        
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        foreach (var file in fileList)
        {
            var content = await File.ReadAllTextAsync(file);
            var header = deserializer.Deserialize<ComponentHeader>(content);

            if (string.Compare(header.Kind, "Persistence", StringComparison.Ordinal) == 0)
            {
                builder.AddStore(header.Metadata.Name, PersistenceLoader.GetPersistenceStore(content));
            }
        }

        return builder.Build();
    }
}