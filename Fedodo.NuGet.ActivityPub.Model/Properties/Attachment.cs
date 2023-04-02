using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.Properties;

/// <summary>
/// Identifies a resource attached or related to an object that potentially requires special handling. The intent is to provide a model that is at least semantically similar to attachments in email.
/// </summary>
public class Attachment
{
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("content")] public string Content { get; set; }
    [JsonPropertyName("url")] public Uri Url { get; set; }
}