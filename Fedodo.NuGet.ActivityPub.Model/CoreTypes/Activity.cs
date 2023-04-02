using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// An Activity is a subtype of Object that describes some form of action that may happen, is currently happening, or has already happened. The Activity type itself serves as an abstract base type for all types of activities. It is important to note that the Activity type itself does not carry any specific semantics about the kind of action being taken.
/// </summary>
public class Activity : Object
{
    [JsonPropertyName("@context")]
    public object? Context { get; set; } = new List<object>
    {
        "https://www.w3.org/ns/activitystreams"
    };

    [JsonPropertyName("id")] public Uri Id { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("actor")] public Uri Actor { get; set; }
    [JsonPropertyName("object")] public object Object { get; set; }
    [JsonPropertyName("published")] public DateTime Published { get; set; }
    [JsonPropertyName("to")] public IEnumerable<string>? To { get; set; }
    [JsonPropertyName("bto")] public IEnumerable<string>? Bto { get; set; }
    [JsonPropertyName("cc")] public IEnumerable<string>? Cc { get; set; }
    [JsonPropertyName("bcc")] public IEnumerable<string>? Bcc { get; set; }
    [JsonPropertyName("audience")] public IEnumerable<string>? Audience { get; set; }
}