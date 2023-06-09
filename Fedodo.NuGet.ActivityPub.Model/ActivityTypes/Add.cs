using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has added the object to the target. If the target property is not explicitly specified,
///     the target would need to be determined implicitly by context. The origin can be used to identify the context from
///     which the object originated.
/// </summary>
public class Add : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Add";
}