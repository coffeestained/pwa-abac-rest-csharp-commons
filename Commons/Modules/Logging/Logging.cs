namespace Common.Modules;

public class CommonLogging : ICommonLogging {
    private ExtendedConfigOptions? _extendedConfig;
    public ExtendedConfigOptions? ExtendedConfig
    {
        get => _extendedConfig;
        set => _extendedConfig = value;
    }

    private CommonLogging(ExtendedConfigOptions? config = ExtendedConfigOptions.CONSOLE) {
        this.ExtendedConfig = config;
    }

    private static CommonLogging? _instance;

    public static CommonLogging GetInstance(ExtendedConfigOptions? config = ExtendedConfigOptions.CONSOLE)
    {
        _instance ??= new CommonLogging(config);
        return _instance;
    }

    public void Log(string level, string message) {
        // Set to Console
        var logMessage = $"{level} - {DateTime.UtcNow} - {message}";

        // Always log to Console
        Console.WriteLine(logMessage);

        // Log to extended config
        // TODO
    }
}

public interface ICommonLogging {
    ExtendedConfigOptions? ExtendedConfig { get; set; }

    void Log(string level, string message);
}

// Configures cloud provider log instances.
// Console will always be enabled and default.
public enum ExtendedConfigOptions { CONSOLE, AWS, AZURE, GCP }

// The highest level of logging available.
// Defaults to highest (DEBUG).
public enum ExtendedLoggingLevelOptions { INFO, ERROR, TRACE, DEBUG }