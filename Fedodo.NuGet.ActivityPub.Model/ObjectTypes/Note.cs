using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Represents a short written work typically less than a single paragraph in length.
/// </summary>
public class Note : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Note";
    [JsonPropertyName("sensitive")] public bool? Sensitive { get; set; }
    
    // Likes and Shares are not used like this by Mastodon and Pixelfed...
    // Keep this in mind.
    [JsonPropertyName("likes")] public Uri? Likes { get; set; }
    [JsonPropertyName("shares")] public Uri? Shares { get; set; }
}