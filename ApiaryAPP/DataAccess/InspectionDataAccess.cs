using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Threading.Tasks;
using ApiaryAPP.ViewModels;
using MongoDB.Driver.Core.Configuration;

namespace ApiaryAPP.DataAccess;
using ApiaryAPP.Models;
using MongoDB.Driver;
using MongoDB.Bson;

public class InspectionDataAccess : MongoDbDataAccess
{
    // private const string ConnectionString =
    //     "mongodb+srv://bjanikk:Fovnvs7sQhmwvWao@apiaryapp.o2vnmgi.mongodb.net/?retryWrites=true&w=majority";
    //
    // private const string DatabaseName = "ApiaryAPP";
    // private const string InspectionCollection = "inspections";
    //
    // public IMongoCollection<InspectionModel> _inspectionCollection;
    //
    // public IMongoCollection<T> ConnectToMongo<T>(in string collection)
    // {
    //     var client = new MongoClient(ConnectionString);
    //     var db = client.GetDatabase((DatabaseName));
    //     return db.GetCollection<T>(collection);
    // }
    private const string InspectionCollection = "inspections";
    public List<InspectionModel> GetInspectionsInfo()
    {
        var collection = ConnectToMongo<InspectionModel>(InspectionCollection); 
        var filter = Builders<InspectionModel>.Filter.Empty;
        var inspections = collection.Find(filter).ToList();
        return inspections;
    }

    public List<InspectionModel> GetInspectionDataByBeehiveId(string beehiveId)
    {
        var collection = ConnectToMongo<InspectionModel>("inspections");
            var filter = Builders<InspectionModel>.Filter.Eq(inspection => inspection.beehiveId, beehiveId);
            var inspections = collection.Find(filter).ToList();

            if (inspections == null)
            {
                throw new Exception("No inspection found.");
            }
            return inspections;
    }
    
    public int GetBeehiveFramesById(int frames)
    {
        Console.WriteLine(frames);
        try
        {
            var collection = ConnectToMongo<InspectionModel>("inspections");
            var filter = Builders<InspectionModel>.Filter.Eq(inspection => inspection.frames, frames);
            var inspections = collection.Find(filter).ToList();
            foreach (var i in inspections)
            {
                Console.WriteLine("Test " + i.beehiveId);
            }

            if (inspections == null)
            {
                throw new Exception("DUPA");
            }
            Console.WriteLine("Jestem tutaj");
            return 555;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 333;
        }
    }

    public void AddInspection(InspectionModel inspection)
    {
        var inspectionCollection = ConnectToMongo<InspectionModel>(InspectionCollection);
        inspectionCollection.InsertOne(inspection);
    }
    
    public InspectionModel GetInspectionByBeehiveId(string beehiveId)
    {
        var collection = ConnectToMongo<InspectionModel>(InspectionCollection);
        var filter = Builders<InspectionModel>.Filter.Eq("BeehiveId", beehiveId);
        return collection.Find(filter).FirstOrDefault();
    }
}