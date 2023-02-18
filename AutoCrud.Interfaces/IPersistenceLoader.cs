namespace AutoCrud.Interfaces;

public interface IPersistenceLoader
{
    bool CanHandle(string type);

    public IPersistence Load(string config);
}