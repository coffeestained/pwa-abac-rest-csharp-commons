using Main.Modules;

namespace Main;

public class Configuration : IConfiguration
{
    private string _connectionString;
    public string ConnectionString
    {
        get => _connectionString;
        set => _connectionString = value;
    }

    private ExtendedConfigOptions _extendedLogging;
    public ExtendedConfigOptions ExtendedLogging
    {
        get => _extendedLogging;
        set => _extendedLogging = value;
    }

    public Configuration(string connectionString, ExtendedConfigOptions extendedLogging) 
    {
        this.ConnectionString = connectionString;
        this.ExtendedLogging = extendedLogging;
    }
}

public interface IConfiguration
{
    string ConnectionString { get; set; }
    
    ExtendedConfigOptions ExtendedLogging { get; set; }
}