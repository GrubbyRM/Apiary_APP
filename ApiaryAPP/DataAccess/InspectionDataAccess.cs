using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiaryAPP.ViewModels;
using MongoDB.Driver.Core.Configuration;

namespace ApiaryAPP.DataAccess;
using ApiaryAPP.Models;
using MongoDB.Driver;
using MongoDB.Bson;

public class InspectionDataAccess
{
    private const string ConnectionString =
        "mongodb+srv://bjanikk:Fovnvs7sQhmwvWao@apiaryapp.o2vnmgi.mongodb.net/?retryWrites=true&w=majority";
    
    private const string DatabaseName = "ApiaryAPP";
    private const string InspectionCollection = "inspections";

    public IMongoCollection<InspectionModel> _inspectionCollection;

    public async Task<InspectionModel> GetAsync(string id) =>
        await _inspectionCollection.Find(x => x.beehiveId == id).FirstOrDefaultAsync();
    public IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase((DatabaseName));
        return db.GetCollection<T>(collection);
    }

    // public async Task<List<InspectionModel>> GetInspectionsInfo()
    // {
    //     var inspectionCollection = ConnectToMongo<InspectionModel>(InspectionCollection);
    //     var results = await inspectionCollection.FindAsync(_ => true);
    //     return results.ToList();
    // }
    
    public List<InspectionModel> GetInspectionsInfo()
    {
        var collection = ConnectToMongo<InspectionModel>(InspectionCollection); // Podstaw odpowiednią nazwę kolekcji
        var filter = Builders<InspectionModel>.Filter.Empty; // Pusty filtr oznacza pobranie wszystkich dokumentów
        var inspections = collection.Find(filter).ToList();
        return inspections;
    }

    public string GetBeehiveNameById(string inspectionDate)
    {
        try
        {
            var collection = ConnectToMongo<InspectionModel>("inspections");
            var filter = Builders<InspectionModel>.Filter.Eq(inspection => inspection.inspectionDate, inspectionDate);
            var inspection = collection.Find(filter).FirstOrDefault();

            if (inspection == null)
            {
                throw new Exception("DUPA");
            }

            return inspection.queenBee;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return string.Empty;
        }
    }
    // public string GetBeehiveNameById(string inspectionDate)
    // {
    //     var collection = ConnectToMongo<InspectionModel>("inspections");
    //     var filter = Builders<InspectionModel>.Filter.Eq(inspection => inspection.inspectionDate, inspectionDate);
    //     var inspection = collection.Find(filter).FirstOrDefault();
    //
    //     return inspection.queenBee;
    // }
    
    // public async Task<List<InspectionModel>> GetInspectionsInfo(FilterDefinition<InspectionModel> filter)
    // {
    //     var inspectionCollection = ConnectToMongo<InspectionModel>(InspectionCollection);
    //     var results = await inspectionCollection.FindAsync(filter);
    //     return results.ToList();
    // }
    
    // public IMongoCollection<T> GetCollection<T>(string collectionName)
    // {
    //     var database = client.GetDatabase("nazwa_bazy_danych"); // Podaj nazwę swojej bazy danych
    //     return database.GetCollection<T>(collectionName);
    // }
    
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
    // public Task AddInspection(InspectionModel inspection)
    // {
    //     var inspectionCollection = ConnectToMongo<InspectionModel>(InspectionCollection);
    //     return inspectionCollection.InsertOneAsync(inspection);
    // }
}