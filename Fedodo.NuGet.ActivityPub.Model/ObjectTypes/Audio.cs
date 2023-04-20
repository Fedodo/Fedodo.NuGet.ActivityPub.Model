using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

public class Audio : Document
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Audio";
}