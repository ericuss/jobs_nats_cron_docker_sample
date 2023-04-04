using MongoDB.Bson;
using MongoDB.Driver;
using Quartz;

namespace SimpleSampleConsole.Jobs.CronJobSample;

public class CronjobSampleJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        // Define the MongoDB connection string and database name
        var databaseName = Environment.GetEnvironmentVariable("Mongo__DBName");
        var connectionString = Environment.GetEnvironmentVariable("Mongo__ConnectionString");

        // Create a MongoClient and get the database
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        // Get the collection and query for all documents
        var collection = database.GetCollection<BsonDocument>("stores");
        var documents = await collection.Find(new BsonDocument()).ToListAsync();

        // Print the documents to the console
        foreach (var document in documents)
        {
            Console.WriteLine(document.ToString());
        }
    }
}
