using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has listened to the object.
/// </summary>
public class Listen : Activity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Listen";
}