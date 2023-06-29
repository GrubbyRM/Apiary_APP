using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiaryAPP.Models;

public class InspectionModel
{
    public ObjectId _id { get; set; }
    [BsonElement("BeehiveId")] public string beehiveId { get; set; }

    public DateTime inspectionDate { get; set; }
    public bool queenBee { get; set; }
    public bool queenCells { get; set; }
    public bool eggs { get; set; }
    public bool openBrood { get; set; }
    public bool closedBrood { get; set; }
    public bool droneBrood { get; set; }
    public bool freshHoney { get; set; }
    public bool cappedHoney { get; set; }
    public bool beeBread { get; set; }

    public int frames { get; set; }
    public int beehiveBoxes { get; set; }
    public int honeyFrames { get; set; }
    public int broodFrames { get; set; }
    public int breadFrames { get; set; }
    public int waxFrames { get; set; }
}