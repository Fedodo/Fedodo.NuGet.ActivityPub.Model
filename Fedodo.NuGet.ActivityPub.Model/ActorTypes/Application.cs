using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

/// <summary>
/// Describes a software application.
/// </summary>
public class Application : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Application";
}