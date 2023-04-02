using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// A Collection is a subtype of Object that represents ordered or unordered sets of Object or Link instances. Refer to the Activity Streams 2.0 Core specification for a complete description of the Collection type.
/// </summary>
public class Collection<T> : Object
{
    [JsonPropertyName("@context")] public string Context { get; set; } = "https://www.w3.org/ns/activitystreams";
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; } = "Collection";
    [JsonPropertyName("totalItems")] public int TotalItems => Items.Count();
    [JsonPropertyName("items")] public IEnumerable<T> Items { get; set; }
}