using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using MongoDB.Bson.Serialization.Attributes;

namespace Fedodo.NuGet.ActivityPub.Model.LinkTypes;

[BsonDiscriminator("Hashtag")]
public class Hashtag : Link
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Hashtag";
}