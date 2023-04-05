using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
/// Represents a video document of any kind.
/// </summary>
public class Video : Document
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Video";
}