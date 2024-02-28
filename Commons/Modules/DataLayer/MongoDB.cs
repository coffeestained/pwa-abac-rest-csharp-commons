using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Common.Modules;

public class MongoDBContext : DbContext
{
    private CommonLogging _logging = null!;
    public CommonLogging Logging
    {
        get => _logging;
        set => _logging = value;
    } 

    private MongoClient _client = null!;
    public MongoClient Client
    {
        get => _client;
        set => _client = value;
    } 

    private IAsyncCursor<BsonDocument> _databases = null!;
    public IAsyncCursor<BsonDocument> Databases
    {
        get => _databases;
        set => _databases = value;
    }

    public MongoDBContext(string uri) 
    {
        // Get Logging Singleton
        this.Logging = CommonLogging.GetInstance();

        // Init Client
        this.Client = new MongoClient(uri);

        // Get List of Current Databases
        this.Databases = this.Client.ListDatabases();
    }

    private static MongoDBContext? _instance;

    public static MongoDBContext GetInstance(string uri)
    {
        _instance ??= new MongoDBContext(uri);
        return _instance;
    }

    public bool IsConnected() 
    {
        var currentState = $"{this.Client.Cluster.Description.State}";
        this.Logging.Log("INFO", $"MongoDB is {currentState}.");
        return currentState == "Connected" ? true : false;
    }

}

// var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

// if (connectionString == null)
// {
//     Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
//     Environment.Exit(0);
// }
// var client = new MongoClient(connectionString);

// var db = MflixDbContext.Create(client.GetDatabase("sample_mflix"));

// var movie = db.Movies.First(m => m.title == "Back to the Future");
// Console.WriteLine(movie.plot);

// internal class MflixDbContext : DbContext
// {
//     public DbSet<Movie> Movies { get; init; }

//     public static MflixDbContext Create(IMongoDatabase database) =>
//         new(new DbContextOptionsBuilder<MflixDbContext>()
//             .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
//             .Options);

//     public MflixDbContext(DbContextOptions options)
//         : base(options)
//     {
//     }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);

//         modelBuilder.Entity<Movie>().ToCollection("movies");
//     }
// }
