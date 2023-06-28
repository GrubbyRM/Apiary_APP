using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiaryAPP.Models;

public class ApiaryModel
{
    public ObjectId _id { get; set; }
    public string beehiveId { get; set; }
    public string queenBee { get; set; }
    public int queenBeeYear { get; set; }
    public string queenBeeProvider { get; set; }
    public string queenBeeType { get; set; }
}