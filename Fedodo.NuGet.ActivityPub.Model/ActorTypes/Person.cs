using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

public class Person : Actor
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Person";
}