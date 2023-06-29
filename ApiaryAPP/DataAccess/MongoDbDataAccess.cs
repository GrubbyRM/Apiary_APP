using ApiaryAPP.Models;
using MongoDB.Driver;

namespace ApiaryAPP.DataAccess;

public class MongoDbDataAccess
{
    private const string ConnectionString =
        "YOUR LINK";

    private const string DatabaseName = "ApiaryAPP";
    // private const string InspectionCollection = "inspections";

    public IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase((DatabaseName));
        return db.GetCollection<T>(collection);
    }
}
