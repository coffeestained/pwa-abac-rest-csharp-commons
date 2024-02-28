using Common.Modules;

namespace Common;

public class Commons : ICommons
{
    private WebApplication _app = null!;
    public WebApplication App
    {
        get => _app;
        set => _app = value;
    }

    private MongoDBContext _mongo = null!;
    public MongoDBContext Mongo
    {
        get => _mongo;
        set => _mongo = value;
    }

    private Configuration _configuration = null!;
    public Configuration Configuration
    {
        get => _configuration;
        set => _configuration = value;
    }

    private CommonLogging _commonLogging = null!;
    public CommonLogging CommonLogging
    {
        get => _commonLogging;
        set => _commonLogging = value;
    } 

    public Commons(Configuration configuration) 
    {
        // Set Config
        this.Configuration = configuration;
        
        // Init Logging
        this.CommonLogging = CommonLogging.GetInstance(configuration.ExtendedLogging);
        this.CommonLogging.Log("INFO", "Initializing commons.");
        
        // Bootstrap
        this.Bootstrap(configuration);
    }

    private void Bootstrap(Configuration configuration) {
        // App
        this.App = WebApplication.Create();

        // Bootstrap MongoDB
        Console.Write(configuration.ConnectionString);
        this.Mongo = MongoDBContext.GetInstance(configuration.ConnectionString);

        Console.Write(this.Mongo.IsConnected());

        // Bootstrap Rest & Socket Files
        try 
        {
            string restFolder = Directory.GetCurrentDirectory() + @"/rest/";
            this.CommonLogging.Log("INFO", $"Searching directory {restFolder}");
            var directory = new DirectoryInfo(restFolder);
            foreach (var file in directory.GetFiles("*.cs"))
            {
                this.CommonLogging.Log("INFO", $"Reading {file} for configured rest route");
            }
        } 
        catch (Exception e)
        {
            this.CommonLogging.Log("INFO", "Failed to bootstrap rest endpoints");
            this.CommonLogging.Log("DEBUG", e.Message);
        }

        try 
        {
            string socketFolder = Directory.GetCurrentDirectory() + @"/socket/";
            this.CommonLogging.Log("INFO", $"Searching directory {socketFolder}");
            var directory = new DirectoryInfo(socketFolder);
            foreach (var file in directory.GetFiles("*.cs"))
            {
                this.CommonLogging.Log("INFO", $"Reading {file} for configured socket route");
            }
        } 
        catch (Exception e)
        {
            this.CommonLogging.Log("INFO", "Failed to bootstrap socket endpoints");
            this.CommonLogging.Log("DEBUG", e.Message);
        }

        // Bootstrap ABAC

    }

    public void Run() {
        this.App.Run($"http://localhost:{this.Configuration.Port}");
    }
}

public interface ICommons
{
    protected WebApplication? App { get; set; }

    protected MongoDBContext? Mongo { get; set; }

    public Configuration Configuration { get; set; }

    public CommonLogging CommonLogging { get; set; }

    public void Run();
}

internal class Run() {
    public static void Main(string[] args)
    {
        // Parse Arguments
        var arguments = new Dictionary<string, string>();
        foreach (string argument in args)
        {
            string[] splitted = argument.Split('=');

            if (splitted.Length == 2)
            {
                arguments[splitted[0]] = splitted[1];
            }
        }
        var parsedConfig = (ExtendedConfigOptions) Enum.Parse(typeof(ExtendedConfigOptions), arguments["LOGGING"]);
        var parsedLogLevel = (ExtendedLoggingLevelOptions) Enum.Parse(typeof(ExtendedLoggingLevelOptions), arguments["LOGLEVEL"]);
        
        // Init Configuration & Lib
        var configuration = new Configuration(int.Parse(arguments["PORT"]), arguments["URI"], parsedConfig, parsedLogLevel);
        var server = new Commons(configuration);

        // Log Config
        server.CommonLogging.Log("INFO", $"Initialized Lib Test");
        server.CommonLogging.Log("DEBUG", $"PORT={int.Parse(arguments["PORT"])} URI={arguments["URI"]} LOGGING={parsedConfig} LOGLEVEL={parsedLogLevel}");

        // Run
        server.Run();
    }
}