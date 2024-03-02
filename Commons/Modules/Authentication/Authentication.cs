using MongoDB.Driver;

namespace Common.Modules;

public class Authentication : IAuthentication
{
    private CommonLogging? _logging;
    public CommonLogging? Logging
    {
        get => _logging;
        set => _logging = value!;
    } 

    private MongoClient _client = null!;
    public MongoClient? Client
    {
        get => _client;
        set => _client = value!;
    } 

    public Authentication() 
    {
        // Get Logging Singleton
        this.Logging = CommonLogging.GetInstance();

        // Init Client
        this.Client =  MongoDBContext.GetInstance(null)!.Client;
    }

    private static Authentication? _instance;

    public static Authentication? GetInstance()
    {
        _instance ??= new Authentication();
        return _instance;
    }

    public static bool IsAuthenticated()
    {
        _instance ??= new Authentication();
        // Going to integrate some sso methodology here.
        return true;
    }
}

public interface IAuthentication {
    protected CommonLogging? Logging { get; set; }
    protected MongoClient? Client { get; set; }
}