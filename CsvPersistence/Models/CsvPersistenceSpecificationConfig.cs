using AutoCrud.Interfaces.Models;

namespace CsvPersistence.Models;

public sealed class CsvPersistenceSpecificationConfig : PersistenceSpecification
{
    public CsvPersistenceMetadata Metadata { get; set; } = new();
}