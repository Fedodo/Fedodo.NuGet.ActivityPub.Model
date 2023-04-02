using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.Properties;

/// <summary>
/// Identifies one or more entities to which this object is attributed. The attributed entities might not be Actors. For instance, an object might be attributed to the completion of another activity.
/// </summary>
public class AttributedTo
{
    [JsonPropertyName("type")] public string Type { get; set; }   
    [JsonPropertyName("name")] public string Name { get; set; }   
}