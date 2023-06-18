using Avalonia;
using Avalonia.Controls;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DatabaseHandler;

    public class DatabaseHandler
    {
        private readonly IMongoClient _client;

        public DatabaseHandler()
        {
            const string connectionUri =
                "mongodb+srv://bjanikk:Fovnvs7sQhmwvWao@apiaryapp.o2vnmgi.mongodb.net/?retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(settings);
        }

    }