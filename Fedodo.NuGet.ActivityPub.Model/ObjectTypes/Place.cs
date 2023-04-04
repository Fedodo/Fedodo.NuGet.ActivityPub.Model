using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
/// Represents a logical or physical location. See 5.3 Representing Places for additional information.
/// </summary>
public class Place : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Place";
    [JsonPropertyName("accuracy")] public double Accuracy { get; set; }
    [JsonPropertyName("latitude")] public double Latitude { get; set; }
    [JsonPropertyName("longitude")] public double Longitude { get; set; }
    [JsonPropertyName("altitude")] public double Altitude { get; set; }
    [JsonPropertyName("radius")] public int Radius { get; set; }
    [JsonPropertyName("units")] public string Units { get; set; }
}