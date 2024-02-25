using Common.Modules;

namespace Common;

public class Configuration : IConfiguration
{
    private string _connectionString = null!;
    public string ConnectionString
    {
        get => _connectionString;
        set => _connectionString = value;
    }
    
    private int _port;
    public int Port
    {
        get => _port;
        set => _port = value;
    }

    private ExtendedConfigOptions _extendedLogging;
    public ExtendedConfigOptions ExtendedLogging
    {
        get => _extendedLogging;
        set => _extendedLogging = value;
    }

    private ExtendedLoggingLevelOptions _extendedLoggingLevel;
    public ExtendedLoggingLevelOptions ExtendedLoggingLevel
    {
        get => _extendedLoggingLevel;
        set => _extendedLoggingLevel = value;
    }

    public Configuration(int port, string connectionString, ExtendedConfigOptions extendedLogging, ExtendedLoggingLevelOptions extendedLoggingLevel) 
    {
        this.Port = port;
        this.ConnectionString = connectionString;
        this.ExtendedLogging = extendedLogging;
        this.ExtendedLoggingLevel = extendedLoggingLevel;
    }
}

public interface IConfiguration
{
    string ConnectionString { get; set; }

    int Port { get; set; }
    
    ExtendedConfigOptions ExtendedLogging { get; set; }
    
    ExtendedLoggingLevelOptions ExtendedLoggingLevel { get; set; }
}