using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is removing the object. If specified, the origin indicates the context from which the
///     object is being removed.
/// </summary>
public class Remove : Activity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Remove";
}