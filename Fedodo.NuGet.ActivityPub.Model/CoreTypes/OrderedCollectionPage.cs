using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// Used to represent ordered subsets of items from an OrderedCollection. Refer to the Activity Streams 2.0 Core for a complete description of the OrderedCollectionPage object.
/// </summary>
public class OrderedCollectionPage : OrderedCollection
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "OrderedCollectionPage";

    [JsonPropertyName("partOf")]
    [JsonConverter(typeof(TripleSetConverter<OrderedCollection>))]
    public TripleSet<OrderedCollection>? PartOf { get; set; }

    [JsonPropertyName("next")]
    [JsonConverter(typeof(TripleSetConverter<OrderedCollectionPage>))]
    public TripleSet<OrderedCollectionPage>? Next { get; set; }

    [JsonPropertyName("prev")]
    [JsonConverter(typeof(TripleSetConverter<OrderedCollectionPage>))]
    public TripleSet<OrderedCollectionPage>? Prev { get; set; }

    [JsonPropertyName("startIndex")] public int StartIndex { get; set; }
}