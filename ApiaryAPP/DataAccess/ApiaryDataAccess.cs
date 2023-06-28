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
}