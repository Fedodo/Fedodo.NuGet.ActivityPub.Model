using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
///     An Activity is a subtype of Object that describes some form of action that may happen, is currently happening, or
///     has already happened. The Activity type itself serves as an abstract base type for all types of activities. It is
///     important to note that the Activity type itself does not carry any specific semantics about the kind of action
///     being taken.
/// </summary>
public class Activity : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Activity";

    [JsonPropertyName("object")]
    [JsonConverter(typeof(ObjectTypeConverter<Object>))]
    public Object? Object { get; set; }

    [JsonPropertyName("actor")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Actor { get; set; }

    [JsonPropertyName("target")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Target { get; set; }

    [JsonPropertyName("result")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Result { get; set; }

    [JsonPropertyName("origin")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Origin { get; set; }

    [JsonPropertyName("instrument")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Instrument { get; set; }
}