using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Describes a relationship between two individuals. The subject and object properties are used to identify the
///     connected individuals.
///     See 5.2 Representing Relationships Between Entities for additional information.
/// </summary>
public class Relationship : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Relationship";

    [JsonPropertyName("subject")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Subject { get; set; }

    [JsonPropertyName("object")] public Object? Object { get; set; }

    [JsonPropertyName("relationship")]
    [JsonConverter(typeof(TripleSetConverter<Relationship>))]
    public TripleSet<Relationship>? RelationshipOf { get; set; }
}