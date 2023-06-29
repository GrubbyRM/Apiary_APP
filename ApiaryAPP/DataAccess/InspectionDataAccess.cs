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

        return inspections;
    }

    public void AddInspection(InspectionModel inspection)
    {
        var inspectionCollection = ConnectToMongo<InspectionModel>(InspectionCollection);
        inspectionCollection.InsertOne(inspection);
    }
}