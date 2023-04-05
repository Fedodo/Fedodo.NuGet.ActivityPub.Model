using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// Describes an object of any kind. The Object type serves as the base type for most of the other kinds of objects defined in the Activity Vocabulary, including other Core types such as Activity, IntransitiveActivity, Collection and OrderedCollection.
/// </summary>
public class Object
{
    [JsonPropertyName("type")] public string Type { get; set; } = "Object";
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("nameMap")] public Dictionary<string, string>? NameMap { get; set; }
    [JsonPropertyName("endTime")] public DateTime? EndTime { get; set; }
    [JsonPropertyName("published")] public DateTime? Published { get; set; }
    [JsonPropertyName("replies")] public Collection? Replies { get; set; }
    [JsonPropertyName("startTime")] public DateTime? StartTime { get; set; }
    [JsonPropertyName("summary")] public string? Summary { get; set; }
    [JsonPropertyName("summaryMap")] public Dictionary<string, string>? SummaryMap { get; set; }
    [JsonPropertyName("updated")] public DateTime? Updated { get; set; }
    [JsonPropertyName("duration")] public string? Duration { get; set; } // Must be xsd:Duration
    [JsonPropertyName("mediaType")] public string? MediaType { get; set; } // Must be a MIME Media Type
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("contentMap")] public Dictionary<string, string>? ContentMap { get; set; }

    
    [JsonPropertyName("icon")]
    [JsonConverter(typeof(TripleSetConverter<Image>))]
    public TripleSet<Image>? Icon { get; set; }

    [JsonPropertyName("image")]
    [JsonConverter(typeof(TripleSetConverter<Image>))]
    public TripleSet<Image>? Image { get; set; }

    [JsonPropertyName("attachment")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Attachment { get; set; }

    [JsonPropertyName("attributedTo")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? AttributedTo { get; set; }

    [JsonPropertyName("audience")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Audience { get; set; }

    [JsonPropertyName("@context")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Context { get; set; }

    [JsonPropertyName("generator")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Generator { get; set; }

    [JsonPropertyName("inReplyTo")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? InReplyTo { get; set; }

    [JsonPropertyName("location")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Location { get; set; }

    [JsonPropertyName("preview")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Preview { get; set; }

    [JsonPropertyName("tag")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Tag { get; set; }

    [JsonPropertyName("url")]
    [JsonConverter(typeof(LinkConverter))]
    public Link? Url { get; set; }

    [JsonPropertyName("to")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? To { get; set; }

    [JsonPropertyName("bto")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Bto { get; set; }

    [JsonPropertyName("cc")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Cc { get; set; }

    [JsonPropertyName("bcc")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Bcc { get; set; }
}