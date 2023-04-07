using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
///     A subtype of Collection in which members of the logical collection are assumed to always be strictly ordered.
/// </summary>
public class OrderedCollection : Collection
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "OrderedCollection";

    [JsonPropertyName("orderedItems")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public new TripleSet<Object>? Items { get; set; }

    [JsonPropertyName("current")]
    [JsonConverter(typeof(TripleSetConverter<OrderedCollectionPage>))]
    public new TripleSet<OrderedCollectionPage>? Current { get; set; }

    [JsonPropertyName("first")]
    [JsonConverter(typeof(TripleSetConverter<OrderedCollectionPage>))]
    public new TripleSet<OrderedCollectionPage>? First { get; set; }

    [JsonPropertyName("last")]
    [JsonConverter(typeof(TripleSetConverter<OrderedCollectionPage>))]
    public new TripleSet<OrderedCollectionPage>? Last { get; set; }
}