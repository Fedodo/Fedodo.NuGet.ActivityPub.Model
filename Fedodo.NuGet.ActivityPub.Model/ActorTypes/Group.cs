using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

public class Group : Actor
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Group";
}