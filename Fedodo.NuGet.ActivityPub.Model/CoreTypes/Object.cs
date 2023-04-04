using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// Describes an object of any kind. The Object type serves as the base type for most of the other kinds of objects defined in the Activity Vocabulary, including other Core types such as Activity, IntransitiveActivity, Collection and OrderedCollection.
/// </summary>
public class Object
{
    [JsonPropertyName("type")] public string Type { get; set; } = "Object";
    [JsonPropertyName("attachment")] public IEnumerable<Object>? Attachment { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("attributedTo")] public IEnumerable<Object>? AttributedTo { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("audience")] public IEnumerable<Object>? Audience { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("mediaType")] public string? MediaType { get; set; } // Must be a MIME Media Type
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("contentMap")] public Dictionary<string, string>? ContentMap { get; set; }
    [JsonPropertyName("@context")] public IEnumerable<Object>? Context { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("nameMap")] public Dictionary<string, string>? NameMap { get; set; }
    [JsonPropertyName("endTime")] public DateTime? EndTime { get; set; }
    [JsonPropertyName("generator")] public IEnumerable<Object>? Generator { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("icon")] public Image? Icon { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("image")] public Image? Image { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("inReplyTo")] public IEnumerable<Object>? InReplyTo { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("location")] public IEnumerable<Object>? Location { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("preview")] public IEnumerable<Object>? Preview { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("published")] public DateTime? Published { get; set; }
    [JsonPropertyName("replies")] public Collection? Replies { get; set; }
    [JsonPropertyName("startTime")] public DateTime? StartTime { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("summaryMap")] public Dictionary<string, string>? SummaryMap { get; set; }
    [JsonPropertyName("tag")] public IEnumerable<Object>? Tag { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("updated")] public DateTime? Updated { get; set; }
    [JsonPropertyName("url")] public Link? Url { get; set; } // TODO Also might be a String-Link
    [JsonPropertyName("duration")] public string? Duration { get; set; } // Must be xsd:Duration
    [JsonPropertyName("to")] public IEnumerable<Object>? To { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("bto")] public IEnumerable<Object>? Bto { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("cc")] public IEnumerable<Object>? Cc { get; set; } // TODO Also might be Link or String-Link
    [JsonPropertyName("bcc")] public IEnumerable<Object>? Bcc { get; set; } // TODO Also might be Link or String-Link
}