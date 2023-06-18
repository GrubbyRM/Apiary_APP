using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiaryAPP.Models;

public class InspectionModel
{

    public ObjectId _id { get; set; }
    [BsonElement("BeehiveId")]
    public string beehiveId { get; set; }

    public string inspectionDate { get; set; }
    public string queenBee { get; set; }
    public string queenCells { get; set; }
    // public bool Eggs { get; set; }
    // public bool OpenBrood { get; set; }
    // public bool ClosedBrood { get; set; }
    // public bool DroneBrood { get; set; }
    // public bool FreshHoney { get; set; }
    // public bool CappedHoney { get; set; }
    // public bool BeeBread { get; set; }
    //
    // public int Frames { get; set; }
    // public int BeehiveBoxes { get; set; }
    // public int HoneyFrames { get; set; }
    // public int BroodFrames { get; set; }
    // public int BreadFrames { get; set; }
    // public int WaxFrames { get; set; }
    

}