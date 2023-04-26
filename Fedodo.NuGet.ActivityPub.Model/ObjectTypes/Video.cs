using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Represents a video document of any kind.
/// </summary>
public class Video : Document
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Video";
}