using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
/// Indicates that the actor accepts the object. The target property can be used in certain circumstances to indicate the context into which the object has been accepted.
/// </summary>
public class Accept : Activity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Accept";
}