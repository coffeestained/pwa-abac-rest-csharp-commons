using Main.Modules;

namespace Main;

public class Commons : ICommons
{
    private WebApplication? _app;
    public WebApplication? App
    {
        get => _app;
        set => _app = value;
    }

    private string[]? _restFiles;
    public string[]? RestFiles
    {
        get => _restFiles;
        set => _restFiles = value;
    }

    private string[]? _socketFiles;
    public string[]? SocketFiles
    {
        get => _socketFiles;
        set => _socketFiles = value;
    }

    public Logging Logging
    {
        get => Logging;
        set => Logging = value;
    }

    public Commons(Configuration configuration) 
    {
        // App
        this.App = WebApplication.Create();

        // Bootstrap Rest & Socket Files
        string csFiles = "*.cs";
        Console.Write(Environment.ProcessPath);
        string restFolder = Path.GetDirectoryName(Environment.ProcessPath) + @"\rest\";
        string socketFolder = Path.GetDirectoryName(Environment.ProcessPath) + @"\socket\";
        this.RestFiles = Directory.GetFiles(restFolder, csFiles);
        this.SocketFiles = Directory.GetFiles(socketFolder, csFiles);

        // Bootstrap MongoDB

        // Bootstrap ABAC

        // Bootstrap Logging
        this.Logging = new Logging(configuration.ExtendedLogging);
        Console.Write("TEST");
        this.Logging.Log("INFO", "TESTING");
    }

    public static void Main(string[] args)
    {
        Console.Write(args);
        var configuration = new Configuration("mongodb://192.168.50.208:27017/", ExtendedConfigOptions.CONSOLE);
        new Commons(configuration);
    }
}

public interface ICommons
{
    WebApplication? App { get; set; }

    string[]? RestFiles { get; set; }

    string[]? SocketFiles { get; set; }

    public Logging Logging { get; set; }
}