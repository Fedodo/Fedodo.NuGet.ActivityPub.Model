using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is ignoring the object. The target and origin typically have no defined meaning.
/// </summary>
public class Ignore : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Ignore";
}