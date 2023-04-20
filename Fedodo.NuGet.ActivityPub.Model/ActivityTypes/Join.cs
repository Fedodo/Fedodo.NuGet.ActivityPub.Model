using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has joined the object. The target and origin typically have no defined meaning.
/// </summary>
public class Join : Activity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Join";
}