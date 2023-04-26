using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

/// <summary>
///     Describes a software application.
/// </summary>
public class Application : Actor
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Application";
}