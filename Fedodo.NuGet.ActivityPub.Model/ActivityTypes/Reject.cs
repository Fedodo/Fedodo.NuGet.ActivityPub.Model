using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is rejecting the object. The target and origin typically have no defined meaning.
/// </summary>
public class Reject : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Reject";
}