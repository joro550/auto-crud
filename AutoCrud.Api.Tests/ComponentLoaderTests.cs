using AutoCrud.Logic;
using AutoCrud.Interfaces;

namespace AutoCrud.Api.Tests;

public class ComponentLoaderTests
{
    [Fact]
    public async Task LoadsCorrectPersistence()
    {
        var fileList = new List<string>
        {
            "./Files/storage-csv-example.yml"
        };
        
        var component = await ComponentLoader.LoadComponents(fileList);
        var store = component.GetStore("customers-csv");

        var storeValue = store
            .Some(v => v)
            .None(() => new NullPersistence());
        Assert.IsType<CsvPersistence.CsvPersistence>(storeValue);
    }
}