using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has moved object from origin to target. If the origin or target are not specified, either
///     can be determined by context.
/// </summary>
public class Move : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Move";
}