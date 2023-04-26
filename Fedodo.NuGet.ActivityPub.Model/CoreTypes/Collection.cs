using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
///     A Collection is a subtype of Object that represents ordered or unordered sets of Object or Link instances. Refer to
///     the Activity Streams 2.0 Core specification for a complete description of the Collection type.
/// </summary>
public class Collection : Object
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Collection";

    [JsonPropertyName("totalItems")]
    public int TotalItems =>
        Items?.Links?.Count() ?? 0 + Items?.Objects?.Count() ?? 0 + Items?.StringLinks?.Count() ?? 0;

    [JsonPropertyName("items")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Items { get; set; }

    [JsonPropertyName("current")]
    [JsonConverter(typeof(TripleSetConverter<CollectionPage>))]
    public TripleSet<CollectionPage>? Current { get; set; }

    [JsonPropertyName("first")]
    [JsonConverter(typeof(TripleSetConverter<CollectionPage>))]
    public TripleSet<CollectionPage>? First { get; set; }

    [JsonPropertyName("last")]
    [JsonConverter(typeof(TripleSetConverter<CollectionPage>))]
    public TripleSet<CollectionPage>? Last { get; set; }
}