using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
/// An image document of any kind
/// </summary>
public class Image : Document
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Image";
    [JsonPropertyName("width")] public int Width { get; set; }
    [JsonPropertyName("height")] public int Height { get; set; }
}