using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using MongoDB.Bson.Serialization.Attributes;

namespace Fedodo.NuGet.ActivityPub.Model.LinkTypes;

[BsonDiscriminator("Mention")]
public class Mention : Link
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Mention";
}