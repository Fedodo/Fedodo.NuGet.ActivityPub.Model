using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
/// Indicates that the actor has viewed the object.
/// </summary>
public class View : Activity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "View";
}