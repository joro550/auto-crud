namespace AutoCrud.Interfaces.Models;

public class ComponentHeader
{
    public string Kind { get; set; } = string.Empty;
    public Metadata Metadata { get; set; } = new();
}