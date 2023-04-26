using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

public class Person : Actor
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Person";
}