namespace Common.Modules;

public class Logging : ILogging {
    private ExtendedConfigOptions? _extendedConfig;
    public ExtendedConfigOptions? ExtendedConfig
    {
        get => _extendedConfig;
        set => _extendedConfig = value;
    }

    public Logging(ExtendedConfigOptions config = ExtendedConfigOptions.CONSOLE) {
        this.ExtendedConfig = config;
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

public interface ILogging {
    ExtendedConfigOptions? ExtendedConfig { get; set; }

    void Log(string level, string message);
}

public enum ExtendedConfigOptions { CONSOLE, AWS, AZURE, GCP }