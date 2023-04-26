using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is offering the object. If specified, the target indicates the entity to which the object
///     is being offered.
/// </summary>
public class Offer : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Offer";
}