using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     An IntransitiveActivity that indicates that the actor has arrived at the location. The origin can be used to
///     identify the context from which the actor originated. The target typically has no defined meaning.
/// </summary>
public class Arrive : IntransitiveActivity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Arrive";
}