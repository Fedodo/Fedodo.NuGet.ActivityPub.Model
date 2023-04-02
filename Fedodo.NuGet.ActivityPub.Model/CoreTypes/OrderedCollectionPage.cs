using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// Used to represent ordered subsets of items from an OrderedCollection. Refer to the Activity Streams 2.0 Core for a complete description of the OrderedCollectionPage object.
/// </summary>
/// <typeparam name="T"></typeparam>
public class OrderedCollectionPage<T> : CollectionPage<T>
{
    [JsonPropertyName("@context")] public string Context { get; set; } = "https://www.w3.org/ns/activitystreams";
    [JsonPropertyName("type")] public string Type { get; set; } = "OrderedCollectionPage";
    [JsonPropertyName("orderedItems")] public IEnumerable<T> OrderedItems { get; set; }
    [JsonPropertyName("next")] public Uri Next { get; set; }
    [JsonPropertyName("prev")] public Uri Prev { get; set; }
    [JsonPropertyName("partOf")] public Uri PartOf { get; set; }
    [JsonPropertyName("id")] public Uri Id { get; set; }
}