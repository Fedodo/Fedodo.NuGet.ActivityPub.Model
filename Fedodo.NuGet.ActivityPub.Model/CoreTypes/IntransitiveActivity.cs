using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
///     Instances of IntransitiveActivity are a subtype of Activity representing intransitive actions. The object property
///     is therefore inappropriate for these activities.
/// </summary>
public class IntransitiveActivity : Activity<Object> 
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "IntransitiveActivity";
    [JsonPropertyName("object")] public new Object? Object { get; } = null;
}