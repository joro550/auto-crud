using AutoCrud.Interfaces.Models;

namespace CsvPersistence.Models;

public sealed class CsvPersistenceComponentConfig : ComponentHeader
{
    public CsvPersistenceSpecificationConfig Spec { get; set; } = new();
}