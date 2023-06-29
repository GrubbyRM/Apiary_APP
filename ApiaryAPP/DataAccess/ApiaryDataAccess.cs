using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiaryAPP.ViewModels;
using MongoDB.Driver.Core.Configuration;
using ApiaryAPP.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ApiaryAPP.DataAccess;

public class ApiaryDataAccess : MongoDbDataAccess
{
    private const string Collection = "beehives";

    public void AddBeehive(ApiaryModel beehive)
    {
        var beehiveCollection = ConnectToMongo<ApiaryModel>(Collection);
        beehiveCollection.InsertOne(beehive);
    }

    public void DeleteByBeehiveId(string beehiveId)
    {
        var beehiveCollection = ConnectToMongo<ApiaryModel>(Collection);
        var filter = Builders<ApiaryModel>.Filter.Eq("beehiveId", beehiveId);
        beehiveCollection.DeleteMany(filter);
    }

    public List<ApiaryModel> GetApiary()
    {
        var collection = ConnectToMongo<ApiaryModel>(Collection);
        // var filter = Builders<ApiaryModel>.Filter.Eq(beehive => beehive.beehiveId, beehiveId);
        var beehives = collection.Find(_ => true).ToList();

        return beehives;
    }

    public List<string> GetDistinctBeehiveIds()
    {
        var collection = ConnectToMongo<ApiaryModel>("beehives");
        var filter = Builders<ApiaryModel>.Filter.Empty;
        var distinctBeehiveIds = collection.Distinct<string>("beehiveId", filter).ToList();

        return distinctBeehiveIds;
    }
}