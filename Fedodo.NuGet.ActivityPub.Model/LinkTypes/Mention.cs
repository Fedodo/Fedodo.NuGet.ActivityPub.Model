using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.LinkTypes;

public class Mention : CoreTypes.Link
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Mention";
}