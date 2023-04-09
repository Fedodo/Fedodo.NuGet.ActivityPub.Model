using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

public class Service : Actor
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Service";
}