using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
///     Used to represent distinct subsets of items from a Collection. Refer to the Activity Streams 2.0 Core for a
///     complete description of the CollectionPage object.
/// </summary>
public class CollectionPage : Collection
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "CollectionPage";

    [JsonPropertyName("partOf")]
    [JsonConverter(typeof(TripleSetConverter<Collection>))]
    public TripleSet<Collection>? PartOf { get; set; }

    [JsonPropertyName("next")]
    [JsonConverter(typeof(TripleSetConverter<CollectionPage>))]
    public TripleSet<CollectionPage>? Next { get; set; }

    [JsonPropertyName("prev")]
    [JsonConverter(typeof(TripleSetConverter<CollectionPage>))]
    public TripleSet<CollectionPage>? Prev { get; set; }
}