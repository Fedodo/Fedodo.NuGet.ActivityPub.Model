using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

public class Audio : Document
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Audio";
}