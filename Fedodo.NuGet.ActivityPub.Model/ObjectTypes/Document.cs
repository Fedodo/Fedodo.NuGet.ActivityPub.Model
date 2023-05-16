using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Represents a document of any kind.
/// </summary>
[BsonDiscriminator("Document")]
public class Document : Object
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Document";
}