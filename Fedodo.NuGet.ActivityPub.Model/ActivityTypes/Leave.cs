using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has left the object. The target and origin typically have no meaning.
/// </summary>
public class Leave : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Leave";
}