using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
/// From Mastodon. Used in Actors to describe the about tabs.
/// </summary>
public class PropertyValue : Object
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "PropertyValue";
    [JsonPropertyName("value")] public string Value { get; set; }
}