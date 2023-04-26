using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

public class Group : Actor
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Group";
}