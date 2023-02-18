namespace AutoCrud.Interfaces.Models;

public class PersistenceComponent : ComponentHeader
{
    public PersistenceSpecification Spec { get; set; } = new();
}